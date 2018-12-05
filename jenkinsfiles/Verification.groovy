pipeline
	{
	agent none
		stages
		{
			stage('Checkout')
			{
				steps
				{
					script
					{
						node 
						{
							checkout scm
						}
					}
				}
			}
			stage('Build')
			{
				steps
				{
					script
					{
						node 
						{
							bat "\"${MSBuild}\" /t:Restore AuthenticationWS.sln"
							bat "\"${MSBuild}\" AuthenticationWS.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
						}
					}
				}
			}
			stage('Archive')
			{
				steps
				{
					script
					{
						node 
						{
							archive 'AuthenticationWS/bin/Release/**'
						}
					}
				}
			}
	}
		post
		{
			failure
				{
					mail to: 'attendancesystemkea@gmail.com',
					subject: "Failed Pipeline: ${currentBuild.fullDisplayName}",
					body: "Something is wrong with ${env.BUILD_URL}"
					echo "sent"
				}
	    }
	}