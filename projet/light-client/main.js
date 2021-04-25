var lat1 = 0, lng1 = 0, lat2 = 0, lng2 = 0, lat3 = 0, lng3 = 0, lat4 = 0, lng4 = 0;

// This function is called when a XML call is finished. In this context, "this" refers to the API response.
function feedContractList() {

    // First of all, check that the call went through OK:
    if (this.status !== 200) {
        console.log("Contracts not retrieved. Check the error in the Network or Console tab.");
    } else {
        var parsed_list = JSON.parse(this.responseText);
        var path1 = parsed_list.AllPath[0].Features;
        var path2 = null; 
        var path3 = null;
        if(parsed_list.AllPath.length>1){

            path2 = parsed_list.AllPath[1].Features;
            path3 = parsed_list.AllPath[2].Features;
        
        }
        var postions = parsed_list.positions;
        var latlngs = Array();

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
        if(path2 != null && path3 != null) {
            console.log(path2);
            L.geoJSON(path2).addTo(mymap);

            console.log(path3);
            L.geoJSON(path3).addTo(mymap);
        }
        lat1 = postions[0].Lat;
        lng1 = postions[0].Lng;

        var marker1 = L.marker([lat1, lng1]).addTo(mymap)
        .bindPopup("<b>start</b><br />").openPopup();

        lat2 = postions[1].Lat;
        lng2 = postions[1].Lng;


        var marker2 = L.marker([lat2, lng2]).addTo(mymap)
        .bindPopup("<b>destination</b><br />").openPopup();

        //Get latlng from first marker
        latlngs.push(marker1.getLatLng());
        
        //Get latlng from first marker
        latlngs.push(marker2.getLatLng());

        if(postions.length>2){

            lat3= postions[2].Lat;
            lng3 = postions[2].Lng;

            var marker3 = L.marker([lat3, lng3]).addTo(mymap)
            .bindPopup("<b>station-start</b><br />").openPopup();
            
            lat4= postions[3].Lat;
            lng4 = postions[3].Lng;

            var marker4 = L.marker([lat4, lng4]).addTo(mymap)
            .bindPopup("<b>station-end</b><br />").openPopup();   
            
            latlngs.push(marker3.getLatLng());

            latlngs.push(marker4.getLatLng());

        }
        //You can just keep adding markers
        
        //From documentation http://leafletjs.com/reference.html#polyline
        // create a red polyline from an arrays of LatLng points
        var path = L.polyline.antPath(latlngs, {color: 'red'}).addTo(mymap);
        
        // zoom the mymap to the polyline
        mymap.fitBounds(path.getBounds())


        document.getElementById("mapid").style.display = "block";

    }
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

}

