In House Developer  Documentation
Last updated: 16/03/2019
App version: v0.5(pre-Alpha)
-Auth0: dev-9gmocm7w.eu.auth0.com


DATA DRIVEN APP.(So always think how will the data flow)

1.  Application Structure 
	Behaviours - UI Behaviours, MVVM approach
	Cells - Views(UI) is broken down into smaller pieces and placed here
	Models - Where the Bussiness objects stay
	Controls - Create/Extend controls for UI elements
	Helpers - 
	PopUpMessages - Pop up views
	TabbedPages - where the Main Pages are situated(mainly because they are unique)
	ViewModels - The UI DataBinding
	Views - Where all UI elements belong

2.	 Extended Package Requirement(#Purpose)
	
	-Xamarin.Forms v3.3.0.96xx (Main API)
	-Xamarin.Auth v1.6.0.4( Autentication)
	-Xamarin.Forms.BehaviorsPack v2.1.0 (Custom Behavior library)
	-Com.Airbnb.Xamarin.Forms.Lottie v2.7.1(Animation)
	-MongoDB.Driver & MongoDB.Driver v2.8.0(Database)
	-Plugin.Permissions v3(Device Hardware premissions)
	-Rg.Plugins.Popup v1.1.4.168(Pop up pages)
	-Xam.Plugin.Connectivity v3.2(Network connectivity)
	-Xam.Plugin.Geolocator v4.5.0.6 (access geolocation)
	-Xam.Plugins.Forms.ImageCircle v3.0.0.5 (Circle Image)
	-Xamarin.GooglePlayServices.Auth v60.11.1142.1 (Android Bindings for Google Play Services)
	-ZXing.Net.Mobile v2.4.1 (Scanning Barcodes)

3. Coding standards
	-Keep code clean, when overloading a method use this format pass 1)numerical values then 2)Strings and finally 3) Objects
	eg. Method(int,float,double,string,object)

	Method Naming must make sense. 
	If method populates a list dont name it EmptyList() for example.

	-Add comments for none boilerplate code	

4.

3.  Connecting To Main WEB API(Hosted on GCP)
	BaseUrl		      : http://35.224.114.206/api/

	Main Controls : Doctors
					-GET
					-POST
					-PUT
					Account
					-GET
					-POST
					-PUT
					Patient
					-GET
					-POST
					-PUT					
					Payment
					-GET
					-POST
					-PUT

