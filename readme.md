We will create a simple application with dotnet-core

we will use the images created here istio-example [istio-example](https://github.com/OktaySavdi/istio-example)


#  Build
````
docker build -t istioproject:v1 -f Dockerfile .
````
# Run
````
docker run -d -p 5000:8080 --name myapp istioproject:v1
````
# Call
````
curl http://localhost:5000/istio
````
