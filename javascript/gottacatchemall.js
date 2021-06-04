function GetPokemon(){

    let xhr = new XMLHttpRequest();
    let pokemon = {};
    let pokemon2Find = document.querySelector('#needToFindPokemon').value;
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status > 199 && this.status < 300){
            pokemon = JSON.parse(xhr.responseText);
            document.querySelector('.foundPokemon img').setAttribute('src', pokemon.sprites.front_default);
            document.querySelectorAll('.foundPokemon caption').forEach((element) => element.remove());
            let caption = document.createElement('caption');
            let pokemonName = document.createTextNode(pokemon.forms[0].name);
            caption.appendChild(pokemonName)
            document.querySelector('.foundPokemon').appendChild(caption)
            document.querySelector('#needToFindPokemon').value = '';
        } 
    }
    //assemble the httprequest
    xhr.open("GET", `https://pokeapi.co/api/v2/pokemon/${pokemon2Find}`, true);
    xhr.send();
}
function GetDigimon()
{
    let digimon2Find = document.querySelector('#needToFindDigimon').value;
    fetch(`https://digimon-api.vercel.app/api/digimon/name/${digimon2Find}`).then(result => result.json())
    .then(digimon => {
        document.querySelector('.foundDigimon img').setAttribute('src', digimon[0].img);
        document.querySelectorAll('.foundDigimon caption').forEach((element) => element.remove());
        let caption = document.createElement('caption');
        caption.appendChild(document.createTextNode(digimon[0].name));
        document.querySelector('.foundDigimon').appendChild(caption);
        document.querySelector('#needToFindDigimon').value = '';
    })
}