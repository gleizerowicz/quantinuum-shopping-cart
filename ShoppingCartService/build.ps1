 param (
    $dtrUsername,
    $dtrPassword
 )

# define specific build number tag, and set this build as latest in DTR
$buildTag = "dtr.neudemo.net/neudesic/shoppingcartservice:$Env:BUILD_BUILDNUMBER"
$latestTag = "dtr.neudemo.net/neudesic/shoppingcartservice:latest"

# build and tag it
docker build -t $buildTag -t $latestTag .

# login to dtr and push both build and latest
docker login --username $dtrUsername --password $dtrPassword dtr.neudemo.net 
docker push $buildTag
docker push $latestTag