node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat "\"${MSBuild}\" /t:Restore AuthenticationWS.sln"
		bat "\"${MSBuild}\" AuthenticationWS.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
	
	stage 'Archive'
		archive 'AuthenticationWS/bin/Release/**'
}