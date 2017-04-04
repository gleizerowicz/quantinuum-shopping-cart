# Need to be managing the swarm, not the local Docker host, this requires a cert bundle
cd C:\Users\Administrator\Documents\ucp-bundle-admin
Import-Module .\env.ps1

# Print environment variables
write-host "environment: $env:RELEASE_ENVIRONMENTNAME"
write-host "build number: $env:BUILD_BUILDNUMBER"
write-host "definitionName: $env:RELEASE_DEFINITIONNAME"

# Service Name
$serviceName = $env:RELEASE_DEFINITIONNAME + $env:RELEASE_ENVIRONMENTNAME
write-host "serviceName: $serviceName"

# use VSTS Release Manager environment name to define service to update
docker service update --image dtr.neudemo.net/neudesic/shoppingcartservice:latest $serviceName

# give Docker a second to update the service, otherwise the previous service will return a 200
sleep -Seconds 10

# firstload
$hostnames = @('www','test','dev')
do
{
    foreach ($hostname in $hostnames)
    {
        $fqdn = "$hostname.neudemo.net"
        try
        {
            $resp = Invoke-WebRequest $fqdn
            write-host "firstloading $fqdn : $($resp.StatusCode)"
        }
        catch
        {
            write-host "firstloading $fqdn : ERROR(UNDEFINED)"
        }
        
        if ($resp.StatusCode -eq 200)
        {
            $hostnames = $hostnames -ne $hostname
        }
        $resp = $null #force a fresh resp for each evaluation
    }
    sleep -Seconds 5
}
until ($hostnames.Count -eq 0)


<#
# this script will only update, not create.  TODO: test if service exists, then create/update accordingly.  In the meantime:
docker service create --name dev -p mode=host,target=8000,published=8000 --constraint node.labels.environment==dev dtr.neudemo.net/admin/ddcwindowscontainers:latest
#>