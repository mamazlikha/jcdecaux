// This variable will contain the list of the stations of the chosen contract.
var stations = [];
var lat1 = 0, lng1 = 0, lat2 = 0, lng2 = 0, lat3 = 0, lng3 = 0, lat4 = 0, lng4 = 0;
function callAPI(url, requestType, params, finishHandler) {
    var fullUrl = url;

    // If there are params, we need to add them to the URL.
    if (params) {
        // Reminder: an URL looks like protocol://host?param1=value1&param2=value2 ...
        fullUrl += "?" + params.join("&");
    }

    // The js class used to call external servers is XMLHttpRequest.
    var caller = new XMLHttpRequest();
    caller.open(requestType, fullUrl, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload = finishHandler;

    caller.send();
}

function retrieveAllContracts() {
    var targetUrl = "https://api.jcdecaux.com/vls/v3/contracts";
    var requestType = "GET";
    var params = ["apiKey=" + getApiKey()];

    /* When the contracts are retrieved, we need to fill the contract list in Step2.
    ** This is done in the feedContractList function. */
    var onFinish = feedContractList;

    callAPI(targetUrl, requestType, params, onFinish);
}

function retrieveContractStations() {
    // The selected contract is stored as value of the list input.
    var selectedContract = document.getElementById("chosenContract").value;

    var targetUrl = "https://api.jcdecaux.com/vls/v3/stations";
    var requestType = "GET";
    var params = ["apiKey=" + getApiKey(), "contract=" + selectedContract];

    /* When the contracts are retrieved, we need to fill the contract list in Step2.
    ** This is done in the feedContractList function. */
    var onFinish = feedStationList;

    callAPI(targetUrl, requestType, params, onFinish);
}

// This function is called when a XML call is finished. In this context, "this" refers to the API response.
function feedContractList() {
    // First of all, check that the call went through OK:
    var j = { 0: "0", 1: "0" };

    if (this.status !== 200) {
        console.log("Contracts not retrieved. Check the error in the Network or Console tab.");
    } else {
        var parsed_list = JSON.parse(this.responseText);
        var path1 = parsed_list.AllPath[0].Features;
        var path2 = parsed_list.AllPath[1].Features;
        var path3 = parsed_list.AllPath[2].Features;
        var postions = parsed_list.positions;
        

        var mymap = L.map('mapid').setView([48, 2], 7);
       
        L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
            maxZoom: 18,
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, ' +
                'Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            id: 'mapbox/streets-v11',
            tileSize: 512,
            zoomOffset: -1
        }).addTo(mymap);

        console.log(path1);
        L.geoJSON(path1).addTo(mymap);

        console.log(path2);
        L.geoJSON(path2).addTo(mymap);

        console.log(path3);
        L.geoJSON(path3).addTo(mymap);

        lat1 = postions[0].Lat;
        lng1 = postions[0].Lng;
        var marker1 = L.marker([lat1, lng1]).addTo(mymap)
        .bindPopup("<b>start</b><br />").openPopup();

        lat2 = postions[1].Lat;
        lng2 = postions[1].Lng;


        var marker2 = L.marker([lat2, lng2]).addTo(mymap)
        .bindPopup("<b>station-start</b><br />").openPopup();

        lat3= postions[2].Lat;
        lng3 = postions[2].Lng;

        var marker3 = L.marker([lat3, lng3]).addTo(mymap)
        .bindPopup("<b>station-end</b><br />").openPopup();
        
        lat4= postions[3].Lat;
        lng4 = postions[3].Lng;

        var marker4 = L.marker([lat4, lng4]).addTo(mymap)
        .bindPopup("<b>destination</b><br />").openPopup();


        var latlngs = Array();

        //Get latlng from first marker
        latlngs.push(marker1.getLatLng());
        
        //Get latlng from first marker
        latlngs.push(marker2.getLatLng());
        
        latlngs.push(marker3.getLatLng());


        latlngs.push(marker4.getLatLng());


        //You can just keep adding markers
        
        //From documentation http://leafletjs.com/reference.html#polyline
        // create a red polyline from an arrays of LatLng points
        var path = L.polyline.antPath(latlngs, {color: 'red'}).addTo(mymap);
        
        // zoom the mymap to the polyline
        mymap.fitBounds(path.getBounds())



        /*for (var i=0; i<contracts.length; i++) {
            var currentContract = contracts[i];
            // Create a <option> tag that will contain the contract value.
            var option = document.createElement("option");
            // <option>'s value needs to be in a "value" attribute.
            option.setAttribute("value", currentContract);
            // When the <option> is complete, add it to the list.
            listContainer.appendChild(option);
        }*/

        // When the list is filled, display the Step 4:
        document.getElementById("mapid").style.display = "block";



    }
}

// This function is called when a XML call is finished. In this context, "this" refers to the API response.
function feedStationList() {
    // First of all, check that the call went through OK:
    if (this.status !== 200) {
        console.log("Stations not retrieved. Check the error in the Network or Console tab.");
    } else {
        // Let's fill the stations variable with the list we got from the API:
        stations = JSON.parse(this.responseText);
        // Then let's display the Step 3:
        document.getElementById("step3").style.display = "block";
    }
}

function getApiKey() {
    // Let's first retrieve the input:
    var input = document.getElementById("apiKey");
    // And then return its value:
    return input.value;
}

function getClosestStation() {

    var addressOfStart = document.getElementById("addOfStart").value;
    var addressOfDest = document.getElementById("addOfDest").value;


    var parsed_addressOfStart = addressOfStart.replaceAll(" ", "%20");
    var parsed_addressOfDest = addressOfDest.replaceAll(" ", "%20");

    var uri = "http://localhost:8733/Design_Time_Addresses/RoutingWithBikes/RESTBikeRoutingService/computeRoute?addressOfStart=" + parsed_addressOfStart + "&addressOfDest=" + parsed_addressOfDest;

    var caller = new XMLHttpRequest();

    caller.open('GET', uri, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload = feedContractList;

    caller.send();



    document.getElementById("closestStation").innerHTML = returned;
    // Then let's display the final Step:
    document.getElementById("step4").style.display = "block";

    /*
    

    var currentMinDistance = -1;
    var currentMinDistanceStation = null;

    for (var i=0; i<stations.length; i++) {
        var currentStation = stations[i];
        var distance = getDistanceFrom2GpsCoordinates(latitude, longitude, currentStation.position.latitude, currentStation.position.longitude);
        if (currentMinDistance === -1 || currentMinDistance > distance) {
            currentMinDistance = distance;
            currentMinDistanceStation = currentStation.name;
        }
    }

    document.getElementById("closestStation").innerHTML = currentMinDistanceStation;
    // Then let's display the final Step:
    document.getElementById("step4").style.display = "block";*/
}
function returnedValue() {
    // Let's parse the response:
    var value = JSON.parse(this.responseText);


    console.log(value);
}


function getDistanceFrom2GpsCoordinates(lat1, lon1, lat2, lon2) {
    // Radius of the earth in km
    var earthRadius = 6371;
    var dLat = deg2rad(lat2 - lat1);
    var dLon = deg2rad(lon2 - lon1);
    var a =
        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
        Math.sin(dLon / 2) * Math.sin(dLon / 2)
        ;
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = earthRadius * c; // Distance in km
    return d;
}

function deg2rad(deg) {
    return deg * (Math.PI / 180)
}