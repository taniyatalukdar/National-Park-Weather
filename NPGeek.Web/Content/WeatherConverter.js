function convertValues(desiredUnit) {

    var temperature = document.getElementsByClassName("weather-temperature");
    var button = document.getElementById("tempToggle");

    if (desiredUnit === 'F') {
        for (i = 0; i < temperature.length; i++) {

       
            temperature[i].textContent = Math.round((parseFloat(temperature[i].textContent) * 1.8) + 32, 0);
        }
        button.innerText = "F";
    }
    else {
        // Convert from F to C
        for (i = 0; i < temperature.length; i++)
        {
            temperature[i].textContent = Math.round((parseFloat(temperature[i].textContent) - 32) * 0.556, 0);
        }

        

        button.innerText = "C";
    }

    
}

// When the button is clicked
function btnClick() {
    // If the cookie says F, turn it to C and call convertValues
    if (document.cookie === 'F' || document.cookie === '') {
        document.cookie = 'C';
        convertValues('C');
    }
    else {
        document.cookie = 'F';
        convertValues('F');
    }   
}

// When the page loads
window.onload = function () {
    // If user prefers F, do nothing
    if (document.cookie === 'F' || document.cookie === '')
        return;
    else { // Convert the F values to C
        convertValues('C');
    }

}





    