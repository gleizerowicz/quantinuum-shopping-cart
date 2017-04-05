 param (
    $dtrUsername,
    $dtrPassword,
    $dtrOrganization
 )

# define specific build number tag, and set this build as latest in DTR
$buildTag = "$dtrOrganization/$env:BUILD_DEFINITIONNAME:$Env:BUILD_BUILDNUMBER"
$latestTag = "$dtrOrganization/$env:BUILD_DEFINITIONNAME:latest"

# build and tag it
docker build -t $buildTag -t $latestTag .

# login to dtr and push both build and latest
docker login --username $dtrUsername --password $dtrPassword dtr.neudemo.net 
docker push $buildTag
docker push $latestTag