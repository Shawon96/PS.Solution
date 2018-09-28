var domId=function(_id)
{
  return document.getElementById(_id);
}

var map, marker, curPos = {lat: 13.794734, lng: 90.414222}, infoWindow;
var markerList = [];
/*
var places = []; //all the information should be changed dynamically in the modal-profile when markers are clicked..

	places["3"] = {
		"ID" : "3", //on-click on marker id 3 :
					//Tirget-Link should be 'www.xyz.com/request/place/3' @Request button click
					//Tirget-Link should be 'www.xyz.com/subscribe/place/3' @Subscribe button click

        "OwnerId" : "10",
        "SpotName" : "FUJI TC Parking Spot",
        "SpotLocation" : "Moddhobadda, Badda, Dhaka",
        "PricePerHour" : "20",
        "Capacity" : "30",
        "Lat" : "23.787302", //Lat and Lon of the marker..
        "Lon" : "90.425852"
	};
	
	places["5"] = {
		"ID" : "5",

        "OwnerId" : "12",
        "SpotName" : "SHUVASTU Car Garage",
        "SpotLocation" : "Sahajadpur, Badda, Dhaka",
        "PricePerHour" : "30",
        "Capacity" : "70",
        "Lat" : "23.790175",
        "Lon" : "90.425464"
	};
	
	places["7"] = {
		"ID" : "7",

        "OwnerId" : "15",
        "SpotName" : "Sahajadpur Lake Parking Spot",
        "SpotLocation" : "Sahajadpur, Badda, Dhaka",
        "PricePerHour" : "50",
        "Capacity" : "10",
        "Lat" : "23.788450",
        "Lon" : "90.423308"
	};
    */
var createMarker = function(_pos)
{
    //icon:'placeholder.png',
    marker = new google.maps.Marker({ position: _pos, icon: 'Assets/dist/img/placeholder.png', map: map, title: 'You are Hare..!', draggable: true });
    
	google.maps.event.addListener(marker, 'dragend', function (event) { markerDragged(); });
	google.maps.event.addListener(marker, 'click', function (event) { markerClicked(); });
}

var createPlaceMarker = function(place) {
  console.log("Creating place marker: " + place.ID);
  console.log(place);
  
  markerList[place.ID] = new google.maps.Marker(
    { 
      position: { lat: parseFloat(place.Lat), lng: parseFloat(place.Lon) }, 
      map: map, 
      icon:'Assets/dist/img/placeholder.png', 
      title: place.SpotName, 
      draggable: false 
    }
  );

  markerList[place.ID].addListener('click', markerClicked.bind(this, place.ID));
};

var createWindow = function(_pos)
{
	infoWindow = new google.maps.InfoWindow;
	
	infoWindow.setPosition(_pos);
	infoWindow.setContent('Location found.');
	infoWindow.open(map);
}

function initMap()
{
  map = new google.maps.Map(domId('map'), { zoom: 17, mapTypeId: google.maps.MapTypeId.TERRAIN});
  

  // Try HTML5 geolocation.
  if (navigator.geolocation)
  {
    navigator.geolocation.getCurrentPosition
    (
      function (position)
      {
        var pos = { lat: position.coords.latitude, lng: position.coords.longitude };
		
        map.setCenter(pos);
        /// createMarker(pos);

        /// create place markers
        places.forEach(function(place){
          createPlaceMarker(place);
        });
      },

      function ()
      {
        handleLocationError(true, infoWindow, map.getCenter());
      }
    );
  }
  else
  {
    // Browser doesn't support Geolocation
    handleLocationError(false, infoWindow, map.getCenter());
  }
}

function handleLocationError(browserHasGeolocation, infoWindow, pos)
{
  if (browserHasGeolocation) alert("Geolocation Error..!");
  else alert("Geolocation not supported..!");
}

var mPos = {};//= {lat:0.5, lng:0.5};
function markerDragged()
{
  mPos.lat = marker.getPosition().lat();
  mPos.lng = marker.getPosition().lng();
}

function getPlaceWindow(placeId) {
  //console.log(placeId);
  return '<div class="col-md-12"> <div class="box box-widget widget-user"> ' + 
          ' <div class="widget-user-header bg-aqua-active"> <h3 id="spotName" class="widget-user-username">' + places[placeId].SpotName +'</h3>' +
          ' <h5 id="spotLocation" class="widget-user-desc">' + places[placeId].SpotLocation + '</h5> </div> ' + 
          ' <div class="widget-user-image"> <img class="img-circle" src="Assets/dist/img/user1-128x128.jpg" alt="User Avatar"> </div> ' +
          ' <div class="box-footer" style="color:black"> <div class="row"> <div class="col-sm-4 border-right"> ' +
          ' <div class="description-block"> <h5 id="" class="description-header">$' + places[placeId].PricePerHour + '/hr</h5> ' +
          ' <span class="description-text">RATE</span> </div> </div> <div class="col-sm-4 border-right"> ' +
          ' <div class="description-block"> <!-- <h5 class="description-header">☆☆☆☆☆</h5> --> ' + 
          ' <span class="fa fa-star checked"></span> <span class="fa fa-star checked"></span> <span class="fa fa-star checked"></span>' +
          ' <span class="fa fa-star"></span> <span class="fa fa-star"></span> <span class="description-text">RATINGS</span>' + 
          ' </div></div><div class="col-sm-4"> <div class="description-block"> <h5 class="description-header">0/' + places[placeId].Capacity + '</h5>' +
          ' <span class="description-text">CAPACITY</span> </div>  </div> </div> </div> ' +
          ' <div class="col-sm-6 col-sm-offset-3">' +
          ' <button type="button" class="form-control btn btn-success" tabindex="4" data-toggle="modal" data-target="#myModal" onclick="initModal(' + placeId + ')">BOOK NOW</button> ' +
          ' </div></div> </div>';
}

var markerClicked = function(placeId) {
  infoWindow = new google.maps.InfoWindow({
    pixelOffset: new google.maps.Size(0, -25)
  });
  mPos.lat = parseFloat(places[placeId].Lat);
  mPos.lng = parseFloat(places[placeId].Lon);

  var profile = domId("prof").innerHTML;

  /// process profile
  //console.log(getPlaceWindow(placeId));

  

  infoWindow.setPosition(mPos);
  infoWindow.setContent(getPlaceWindow(placeId));
  infoWindow.open(map);
}

function initModal(placeId) {
  document.getElementById("register-form").action = "/Users/MakeSubscribe";
  document.getElementById("modalSubSpotName").innerHTML = places[placeId].SpotName;
  document.getElementById("modalSubSpotLocation").innerHTML = places[placeId].SpotLocation;
  document.getElementById("modalSubPricePerHour").innerHTML = "$" + places[placeId].PricePerHour;
  document.getElementById("modalSubCapacity").innerHTML = "0/" + places[placeId].Capacity;

  document.getElementById("login-form").action = "/Users/MakeRequest";
  document.getElementById("modalReqSpotName").innerHTML = places[placeId].SpotName;
  document.getElementById("modalReqSpotLocation").innerHTML = places[placeId].SpotLocation;
  document.getElementById("modalReqPricePerHour").innerHTML = "$" + places[placeId].PricePerHour;
  document.getElementById("modalReqCapacity").innerHTML = "0/" + places[placeId].Capacity;
  domId("var1").value = placeId; domId("var2").value = placeId;
  
  console.log("I got: "+domId("var1").value);
  console.log("I got: "+domId("var2").value);
}
/*
function markerClicked()
{
  infoWindow = new google.maps.InfoWindow({
    pixelOffset: new google.maps.Size(0, -25)
  });
  mPos.lat = marker.getPosition().lat();
  mPos.lng = marker.getPosition().lng();

  var profile = domId("prof").innerHTML;

  infoWindow.setPosition(mPos);
  infoWindow.setContent(profile);
  infoWindow.open(map);
}
*/

 /* $(function () {
      //Date picker
      $('#datepicker').datepicker({
          autoclose: true
      })
      //Timepicker
      $('.timepicker').timepicker({
          showInputs: false
      })
  })*/

//Modal script..
$(function() {

  $('#login-form-link').click(function(e) {
  $("#login-form").delay(100).fadeIn(100);
   $("#register-form").fadeOut(100);
  $('#register-form-link').removeClass('active');
  $(this).addClass('active');
  e.preventDefault();
});
$('#register-form-link').click(function(e) {
  $("#register-form").delay(100).fadeIn(100);
   $("#login-form").fadeOut(100);
  $('#login-form-link').removeClass('active');
  $(this).addClass('active');
  e.preventDefault();
});

});