
var map, marker, curPos = {lat: 13.794734, lng: 90.414222}, infoWindow;
function initMap()
{
  map = new google.maps.Map(document.getElementById('map'), {center: curPos, zoom: 17, mapTypeId: google.maps.MapTypeId.TERRAIN});
  infoWindow = new google.maps.InfoWindow;

  // Try HTML5 geolocation.
  if (navigator.geolocation)
  {
    navigator.geolocation.getCurrentPosition
    (
      function (position)
      {
        var pos =
        {
          lat: position.coords.latitude,
          lng: position.coords.longitude
        };

        curPos = pos;
        //document.getElementById("lt").innerHTML = "Lat : " + curPos.lat;
        //document.getElementById("ln").innerHTML = "Lng: " + curPos.lng;

        //infoWindow.setPosition(pos);
        //infoWindow.setContent('Location found.');
        //infoWindow.open(map);
        map.setCenter(pos);

        //var myLatLng = { lat: -25.363, lng: 131.044 };
        marker = new google.maps.Marker({ position: pos, map: map,icon: 'placeholder.png', title: 'You are Hare..!', draggable: true });
        google.maps.event.addListener(marker, 'dragend', function (event) { markerDragged(); });
        google.maps.event.addListener(marker, 'click', function (event) { markerClicked(); });

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
  //infoWindow.setPosition(pos);
  //infoWindow.setContent(browserHasGeolocation ? 'Error: The Geolocation service failed.' : 'Error: Your browser doesn\'t support geolocation.');
  //infoWindow.open(map);
  if (browserHasGeolocation) alert("Geolocation Error..!");
  else alert("Geolocation not supported..!");
}
//var selectMarker = new google.maps.Marker( {position: curPos, map: map, title: 'You GOT this!', draggable: true} );

var mPos = {};//= {lat:0.5, lng:0.5};
function markerDragged()
{
  mPos.lat = marker.getPosition().lat();
  mPos.lng = marker.getPosition().lng();

  document.getElementById("lt").innerHTML = "Lat : " + mPos.lat;
  document.getElementById("ln").innerHTML = "Lng: " + mPos.lng;
}

document.getElementById("info").addEventListener("click", updatePosition);
function updatePosition()
{
  document.getElementById("lt").innerHTML = "Lat : " + curPos.lat;
  document.getElementById("ln").innerHTML = "Lng: " + curPos.lng;
}

function markerClicked()
{
  infoWindow = new google.maps.InfoWindow({
    pixelOffset: new google.maps.Size(0, -25)
  });
  mPos.lat = marker.getPosition().lat();
  mPos.lng = marker.getPosition().lng();

  var html = '<h4 style="color: black">Jamuna Parking Spot..<h4>';
  html += '<h5 style="color: black">Rate: $1.3/hr &nbsp &nbsp Capacity: 3/5<h5>';
  //html += '<button type="button" id="bookBtn" class="btn btn-success">Book</button> &nbsp &nbsp';
  html += '<button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal">BOOK</button> &nbsp &nbsp &nbsp';
  html += '&nbsp &nbsp <button type="button" class="btn btn-danger">CANCEL</button>';

  var profile = document.getElementById("prof").innerHTML;
  

  //infoWindow.innerHTML = document.getElementById("banner").innerHTML;

  infoWindow.setPosition(mPos);
  infoWindow.setContent(profile);
  infoWindow.open(map);
}

var domId=function(_id)
{
  return document.getElementById(_id);
}

//Temp
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