function changeTemp() {
    var temperature = document.getElementsByClassName("weather-temperature");
    if (document.cookie == 'F' || document.cookie == "") {
        
        for (i = 0; i < temperature.length; i++)
        {
            temperature[i].textContent = Math.round((temperature[i].textContent - 32) * 0.556, 0);
        }
        document.cookie = 'C';
    }
    else if (document.cookie == 'C') {
        
        for (i = 0; i < temperature.length; i++)
        {
            temperature[i].textContent = Math.round(((temperature[i].textContent - (9 / 5)) + 32), 0);
        }
        document.cookie = 'F';
    }
};