const fromRates = document.getElementsByName("From")[0];
const toRates = document.getElementsByName("To")[0];
const fromInput = document.getElementById("fromInput");
const toInput = document.getElementById("toInput");

eventlisteners();

function eventlisteners() {

    toRates.addEventListener("change", InputText);
    fromRates.addEventListener("change", InputText);
    fromInput.addEventListener("input", InputText);

}

function InputText(e) {
    GetRates()
        .then(result => {
            toInput.value = fromInput.value * (result.rates[toRates.selectedOptions[0].innerText] / result.rates[fromRates.selectedOptions[0].innerText]);
        });


}

async function GetRates() {
    const response = await fetch("http://api.exchangeratesapi.io/v1/latest?access_key=0e8e6c40cd601ee7352cbb23f0f894d2&format=1");
    const data = response.json();
    return data;
}

$('#showExchangeBtn').click(function () {
    $('#Exchange-rate').slideToggle();
});
$('#Exchange-rate-closeBtn').click(function () {
    $('#Exchange-rate').slideUp();
});

$(document).ready(function () {
    $('#Exchange-rate').slideUp(1);
});