del "*.nupkg"
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack RyanJagdfeld.Module.GitHubCard.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\Packages\" /Y

