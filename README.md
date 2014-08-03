TeamCityZen
===========

##Purpose
TeamCity is much more than just a Continuous Integration server. It is the central communication point of software development organization. Using this plugin you can add communication and sozializing capabilities to your existing TeamCity server.

##How to use
1. Dowload from: [TeamCityZen.zip](http://teamcity.codebetter.com/repository/download/TeamCityZen_TeamCityZenMaster/.lastSuccessful/TeamCityZen.zip) and extract on agent, for example: C:\Tools\TeamCityZen
2. Configure TeamCity and SMTP details in TeamCityZen.exe.config 
3. Add command line step in build configuration with command C:\Tools\TeamCityZen\TeamCityZen.exe /buildId %teamcity.build.id%
4. Use @UserName in comments to notify somebody about your checkin/commit

##Future plans:
1. Add @groupName support to notify group about checkin/commit
2. Port to Java as TeamCity plugin
3. Display link from TeamCity UI to user's profile page
4. Support emoticons in comments and display them on TeamCity UI
5. 
##Continuous Integration:
Last build status is: 
![ci](http://teamcity.codebetter.com/app/rest/builds/buildType:(id:TeamCityZen_TeamCityZenMaster)/statusIcon "ci")

![alt text](http://www.jetbrains.com/img/banners/Codebetter300x250.png "continuous integration server")

##Author
Boris Modylevsky (@bormod)

##License
Apache 2.0
