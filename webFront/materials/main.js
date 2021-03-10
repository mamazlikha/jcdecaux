function retrieveAllContracts(){
    apiKey = document.getElementById("1").value;
    url = "https://api.jcdecaux.com/vls/v1/contracts?apiKey="+apiKey;
    var xhr = new XMLHttpRequest();
    xhr.open('GET', url);
    xhr.setRequestHeader("Accept","application/json");
    xhr.onload = function () {
        console.log(this.responseText); // http://example.com/test
      };
    xhr.send()
    //console.log(url);
}