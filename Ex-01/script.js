fetch("albums.json")
  .then((response) => response.json())
  .then((data) => {
    const albumList = document.getElementById("album-list");
    const table = document.createElement("table");
    table.innerHTML = `
<tr>
<th>Album</th>
<th>Kunstner</th>
<th>År</th>
<th>Trackliste</th>
</tr>
`;
    data.forEach((album) => {
      const row = document.createElement("tr");
      row.innerHTML = `
<td>${album.albumName}</td>
<td>${album.artistName}</td>
<td>${album.productionYear}</td>
<td>
<button onclick="this.nextElementSibling.style.display = this.nextElementSibling.style.display === 'none' ? 'block' : 'none'">
Åben/Luk
</button>
<ul class="tracklist" style="display:none;"></ul>
</td>
`;
      const tracklist = row.querySelector(".tracklist");
      album.trackList.forEach((track) => {
        const li = document.createElement("li");
        li.textContent = `${track.trackNumber}. ${track.trackTitle}`;
        tracklist.appendChild(li);
      });
      table.appendChild(row);
    });
    albumList.appendChild(table);
  });
