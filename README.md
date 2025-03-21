**Drivers / Vehicles License Department**
## This is a winforms application to manage people - users - drivers - licenses (local & international)
### before everything when you clone this repo 
### You neet to create class in the data access project under the name of
***clsDataAccessSettings***
### And create a static string under the name of (ConnectionString) and put your server data in the string 
### I included a database backup restors it and run the application 
### You can use (UserNamem = Msaqer77 Password =1234) to have access to all forms the other users doesn't have all permessions
# Progect tree
### +---Database Backup
### |       DVLD.bak
### |       
### +---DVLD_Buisness
### |   |   Application.cs
### |   |   ApplicationType.cs
### |   |   Country.cs
### |   |   DetainedLicense.cs
### |   |   Driver.cs
### |   |   DVLD_Buisness.csproj
### |   |   InternationalLicense.cs
### |   |   License.cs
### |   |   LicenseClass.cs
### |   |   LocalDrivingLicenseApplication.cs
### |   |   People.cs
### |   |   Test.cs
### |   |   TestAppointment.cs
### |   |   TestType.cs
### |   |   User.cs  
### +---DVLD_DataAccess
### |   |   .editorconfig
### |   |   ApplicationData.cs
### |   |   ApplicationTypesData.cs
### |   |   CountriesData.cs
### |   |   DataAccessSettings.cs
### |   |   DetainedLicense.cs
### |   |   DriverData.cs
### |   |   DVLD_DataAccess.csproj
### |   |   DVLD_DataAccess.sln
### |   |   InternationalLicenseData.cs
### |   |   LicenceClassData.cs
### |   |   LicenseData.cs
### |   |   LocalDrivingLicenseApplicationData.cs
### |   |   PeopleData.cs
### |   |   TestAppointmentsData.cs
### |   |   TestsData.cs
### |   |   TestTypesData.cs
### |   |   UsersData.cs
### |   |   
### +---DVLD_UI
### |   |   App.config
### |   |   app.manifest
### |   |   DVLD_UI.csproj
### |   |   DVLD_UI.sln
### |   |   Program.cs
### |   |   
### |   +---Applications
### |   |   +---ApplicationTypes
### |   |   |       frmManageApplicationTypes.cs
### |   |   |       frmManageApplicationTypes.Designer.cs
### |   |   |       frmManageApplicationTypes.resx
### |   |   |       frmUpdateApllicationType.cs
### |   |   |       frmUpdateApllicationType.Designer.cs
### |   |   |       frmUpdateApllicationType.resx
### |   |   |       
### |   |   +---Controls
### |   |   |       ctrlApplicationBasicInfo.cs
### |   |   |       ctrlApplicationBasicInfo.Designer.cs
### |   |   |       ctrlApplicationBasicInfo.resx
### |   |   |       
### |   |   +---International Licenses
### |   |   |       frmListInternationalLicenses.cs
### |   |   |       frmListInternationalLicenses.Designer.cs
### |   |   |       frmListInternationalLicenses.resx
### |   |   |       frmNewInternationalLicenseApplication.cs
### |   |   |       frmNewInternationalLicenseApplication.Designer.cs
### |   |   |       frmNewInternationalLicenseApplication.resx
### |   |   |       
### |   |   +---Local Driving License
### |   |   |       ctrlDrivingLicenseApplication.cs
### |   |   |       ctrlDrivingLicenseApplication.Designer.cs
### |   |   |       ctrlDrivingLicenseApplication.resx
### |   |   |       frmAddUpdateLocalDrivingLicenseApplication.cs
### |   |   |       frmAddUpdateLocalDrivingLicenseApplication.Designer.cs
### |   |   |       frmAddUpdateLocalDrivingLicenseApplication.resx
### |   |   |       frmListLocalDrivingLicenseApplications.cs
### |   |   |       frmListLocalDrivingLicenseApplications.Designer.cs
### |   |   |       frmListLocalDrivingLicenseApplications.resx
### |   |   |       frmLocalDrivingLicenseApplicationInfo.cs
### |   |   |       frmLocalDrivingLicenseApplicationInfo.Designer.cs
### |   |   |       frmLocalDrivingLicenseApplicationInfo.resx
### |   |   |       
### |   |   +---Release Detained License
### |   |   |       frmListDetainedLicenses.cs
### |   |   |       frmListDetainedLicenses.Designer.cs
### |   |   |       frmListDetainedLicenses.resx
### |   |   |       frmReleaseDetainedLicenseApplication.cs
### |   |   |       frmReleaseDetainedLicenseApplication.Designer.cs
### |   |   |       frmReleaseDetainedLicenseApplication.resx
### |   |   |       
### |   |   +---Renew Local License
### |   |   |       frmRenewLocalLicense.cs
### |   |   |       frmRenewLocalLicense.Designer.cs
### |   |   |       frmRenewLocalLicense.resx
### |   |   |       
### |   |   \---ReplaceLostOrDamagedLicense
### |   |           frmReplaceLostOrDamagedLicense.cs
### |   |           frmReplaceLostOrDamagedLicense.Designer.cs
### |   |           frmReplaceLostOrDamagedLicense.resx
### |   |           
### |   +---Drivers
### |   |       frmListDrivers.cs
### |   |       frmListDrivers.Designer.cs
### |   |       frmListDrivers.resx
### |   |       
### |   +---GlobalClasses
### |   |       clsFormat.cs
### |   |       clsGlobal.cs
### |   |       clsUtil.cs
### |   |       clsValidation.cs
### |   |       
### |   +---Licenses
### |   |   +---Controls
### |   |   |       ctrlDriverLicenses.cs
### |   |   |       ctrlDriverLicenses.Designer.cs
### |   |   |       ctrlDriverLicenses.resx
### |   |   |       
### |   |   +---Detain License
### |   |   |       frmDetainLicense.cs
### |   |   |       frmDetainLicense.Designer.cs
### |   |   |       frmDetainLicense.resx
### |   |   |       
### |   |   +---International Licenses
### |   |   |   |   frmShowInternationalLicenseInfo.cs
### |   |   |   |   frmShowInternationalLicenseInfo.Designer.cs
### |   |   |   |   frmShowInternationalLicenseInfo.resx
### |   |   |   |   
### |   |   |   \---Controls
### |   |   |           ctrlInternationalLicenseInfo.cs
### |   |   |           ctrlInternationalLicenseInfo.Designer.cs
### |   |   |           ctrlInternationalLicenseInfo.resx
### |   |   |           
### |   |   \---Local Licenses
### |   |       |   frmIssueDriverLicenseFirstTime.cs
### |   |       |   frmIssueDriverLicenseFirstTime.Designer.cs
### |   |       |   frmIssueDriverLicenseFirstTime.resx
### |   |       |   frmShowLicenseInfo.cs
### |   |       |   frmShowLicenseInfo.Designer.cs
### |   |       |   frmShowLicenseInfo.resx
### |   |       |   frmShowPersonLicenseHistory.cs
### |   |       |   frmShowPersonLicenseHistory.Designer.cs
### |   |       |   frmShowPersonLicenseHistory.resx
### |   |       |   
### |   |       \---Controls
### |   |               ctrlDriverLicenseInfo.cs
### |   |               ctrlDriverLicenseInfo.Designer.cs
### |   |               ctrlDriverLicenseInfo.resx
### |   |               ctrlDriverLicenseInfoWithFilter.cs
### |   |               ctrlDriverLicenseInfoWithFilter.Designer.cs
### |   |               ctrlDriverLicenseInfoWithFilter.resx
### |   |               
### |   +---Login
### |   |       frmLogin.cs
### |   |       frmLogin.Designer.cs
### |   |       frmLogin.resx
### |   |       
### |   +---Main
### |   |       DVLDMainForm.cs
### |   |       DVLDMainForm.Designer.cs
### |   |       DVLDMainForm.resx
### |   |       
### |   +---People
### |   |   |   frmAddUpdatePerson.cs
### |   |   |   frmAddUpdatePerson.Designer.cs
### |   |   |   frmAddUpdatePerson.resx
### |   |   |   frmFindPerson.cs
### |   |   |   frmFindPerson.Designer.cs
### |   |   |   frmFindPerson.resx
### |   |   |   frmPersonDetails.cs
### |   |   |   frmPersonDetails.Designer.cs
### |   |   |   frmPersonDetails.resx
### |   |   |   frm_ManagePeople.cs
### |   |   |   frm_ManagePeople.Designer.cs
### |   |   |   frm_ManagePeople.resx
### |   |   |   
### |   |   \---My_Controls
### |   |           ctrlPersonWithfilter.cs
### |   |           ctrlPersonWithfilter.Designer.cs
### |   |           ctrlPersonWithfilter.resx
### |   |           PersonCard.cs
### |   |           PersonCard.Designer.cs
### |   |           PersonCard.resx
### |   +---Tests
### |   |   |   frmListTestAppointments.cs
### |   |   |   frmListTestAppointments.Designer.cs
### |   |   |   frmListTestAppointments.resx
### |   |   |   frmSchedualTest.cs
### |   |   |   frmSchedualTest.Designer.cs
### |   |   |   frmSchedualTest.resx
### |   |   |   frmTakeTest.cs
### |   |   |   frmTakeTest.Designer.cs
### |   |   |   frmTakeTest.resx
### |   |   |   
### |   |   +---Controls
### |   |   |       ctrlSchedualTest.cs
### |   |   |       ctrlSchedualTest.Designer.cs
### |   |   |       ctrlSchedualTest.resx
### |   |   |       ctrlScheduledTest.cs
### |   |   |       ctrlScheduledTest.Designer.cs
### |   |   |       ctrlScheduledTest.resx
### |   |   |       
### |   |   \---TestTypes
### |   |           frmManageTestTypes.cs
### |   |           frmManageTestTypes.Designer.cs
### |   |           frmManageTestTypes.resx
### |   |           frmUpdateTestTypes.cs
### |   |           frmUpdateTestTypes.Designer.cs
### |   |           frmUpdateTestTypes.resx
### |   |           
### |   \---Users
### |       |   frmAddUpdateUser.cs
### |       |   frmAddUpdateUser.Designer.cs
### |       |   frmAddUpdateUser.resx
### |       |   frmChangePassword.cs
### |       |   frmChangePassword.Designer.cs
### |       |   frmChangePassword.resx
### |       |   frmManageUsers.cs
### |       |   frmManageUsers.Designer.cs
### |       |   frmManageUsers.resx
### |       |   frmShowUserPermessions.cs
### |       |   frmShowUserPermessions.Designer.cs
### |       |   frmShowUserPermessions.resx
### |       |   frmUserDetails.cs
### |       |   frmUserDetails.Designer.cs
### |       |   frmUserDetails.resx
### |       |   
### |       \---My_Controls
### |               ctrlUserInfo.cs
### |               ctrlUserInfo.Designer.cs
### |               ctrlUserInfo.resx
