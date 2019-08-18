pipeline
{
    agent any

    parameters
    {
        string(name:'UserName',defaultValue:'',description:'Enter Github UserName')
        string(name:'Repository',defaultValue:'',description:'Enter Repository Name')
        string(name:'Branch',defaultValue:'',description:'Enter branch name')
        string(name:'ImageName',defaultValue:'',description:'Enter docker image name')
    }

   

    stages
    {
        stage('Git-Checkout')
        {

            
            steps
            {
                
                git branch: "${params.Branch}", url: "https://github.com/${params.UserName}/${params.Repository}.git"
                echo "The application type is ${params.AppType}"
                echo "Clone Success"
            }
        }

        stage('Build')
        {
            steps
            {
                echo "Building Project"
                bat "dotnet build ${params.Repository}.sln --configuration Release"
                echo "Build success"
            }
        }

        stage('Test')
        {
            steps
            {
                echo "Test start"
                bat "dotnet test ${params.Repository}.sln"
                echo "Test Success"
            }
        }

        stage('Publish-Output')
        {
            steps
            {
                echo "Publish Start"
                bat "dotnet publish ${params.Repository}.sln"
                echo "Publish Success"
            }
        }
        

        stage('Docker-Image-Generation')
        {
            steps
            {
                echo "Starting Docker Image generation"
                bat "docker build --tag=image-${params.ImageName} ."
                echo "Docker Image Generation Successful"
            }
        }

        stage('Docker Push')
        {
            steps
            {
                echo "Pushing image to docker hub"
                
                    script{
                     docker.withRegistry('https://index.docker.io/v1/','docker-hub-credentials')
                        {
                            withCredentials([usernamePassword(credentialsId: 'docker-hub-credentials', passwordVariable: 'pass', usernameVariable: 'user')]) 
                            {
                                 bat "docker tag image-${params.ImageName} ${user}/image-${params.ImageName}"
                                 bat "docker push ${user}/image-${params.ImageName}"

                            }
 
                        }
                    }
                    echo "Pushed Success"
                 
            }
        }
    }
}