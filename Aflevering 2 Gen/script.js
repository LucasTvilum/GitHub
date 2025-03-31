// En funktion til at oprette et albumobjekt
function Album(artist, album, totalTracks, productionYear) {
  this.artist = artist;
  this.album = album;
  this.totalTracks = totalTracks;
  this.productionYear = productionYear;
}

// En funktion til at tilføje et album til siden
function addDivWithAlbum(album, parentid) {
  let parentElement = document.getElementById(parentid);
  let elementToAdd =
    "<div>" +
    "<span>" +
    album.artist +
    "</span> | " +
    album.album +
    " | " +
    "Album contains " +
    album.totalTracks +
    " tracks | " +
    "Produced: " +
    album.productionYear +
    "</div>";

  parentElement.innerHTML = parentElement.innerHTML + elementToAdd;
}

// Henter og viser data fra json
fetchContent("Data/albums.json").then((albums) => {
  let albumObjects = [];

  // Opretter nogle albumobjekter
  for (let i = 0; i < albums.length; i++) {
    const album = new Album(
      albums[i].artistName,
      albums[i].albumName,
      albums[i].trackList.length,
      albums[i].productionYear
    );
    albumObjects.push(album);
  }

  // Viser forhåbenligt album på siden
  albumObjects.forEach(function (a) {
    addDivWithAlbum(a, "content");
  });
});

// Det magiske spell
async function fetchContent(url) {
  let request = await fetch(url);
  let json = await request.json();
  return json;
}
