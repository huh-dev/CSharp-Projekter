async function fetchCharacters() {
    const response = await fetch("https://swapi.py4e.com/api/people/");
    const data = await response.json();
    return data.results;
}

function displayCharacters(characters) {
    const characterGrid = document.querySelector('.character-grid');
    const templateCard = characterGrid.querySelector('.character-card');
    characterGrid.innerHTML = ''; 

    characters.forEach(character => {
        const newCard = templateCard.cloneNode(true);
        const [name, height, birthYear, gender] = newCard.querySelectorAll('h2, p');
        
        name.textContent = character.name;
        height.textContent = `Height: ${character.height} cm`;
        birthYear.textContent = `Birth Year: ${character.birth_year}`;
        gender.textContent = `Gender: ${character.gender}`;
        
        characterGrid.appendChild(newCard);
    });
}

function setupSearch(characters) {
    const searchInput = document.getElementById('searchInput');
    searchInput.addEventListener('input', (e) => {
        const searchTerm = e.target.value.toLowerCase();
        const filteredCharacters = characters.filter(character => 
            character.name.toLowerCase().includes(searchTerm)
        );
        displayCharacters(filteredCharacters);
    });
}

fetchCharacters().then(characters => {
    displayCharacters(characters);
    setupSearch(characters);
});


