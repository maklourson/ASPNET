function initMapCourse(laVileChoisie) {
    console.log(laVileChoisie);
    //$('#lamap').html(' <div id="map" style="height: 300px; margin-top: 50px; position: relative; outline: currentcolor none medium;"></div>');
    //var gpx = "";
    //if (laVileChoisie !== "" && laVileChoisie !== "choisir la ville") {
    //    var villes = {
    //        "Paris": { "lat": 48.852969, "lon": 2.349903 },
    //        "Brest": { "lat": 48.383, "lon": -4.500 },
    //        "Quimper": { "lat": 48.000, "lon": -4.100 },
    //        "Bayonne": { "lat": 43.500, "lon": -1.467 }
    //    };
    //    //affichage des coordonnées de la ville choisie
    //    for (ville in villes) {
    //        if (laVileChoisie.toUpperCase() == ville.toUpperCase()) {
    //            L.map('map').remove();
    //    // Créer l'objet "macarte" et l'insèrer dans l'élément HTML qui a l'ID "map"
    //            macarte = L.map('map').setView([villes[ville].lat, villes[ville].lon], 11);
    //    // Leaflet ne récupère pas les cartes (tiles) sur un serveur par défaut. Nous devons lui préciser où nous souhaitons les récupérer. Ici, openstreetmap.fr
    //    L.tileLayer('https://{s}.tile.openstreetmap.fr/osmfr/{z}/{x}/{y}.png', {
    //        // Il est toujours bien de laisser le lien vers la source des données
    //        attribution: 'données © OpenStreetMap/ODbL - rendu OSM France',
    //        minZoom: 1,
    //        maxZoom: 20
    //    }).addTo(macarte);
      
    //    // Nous parcourons la liste des villes
       
    //            var marker = L.marker([villes[ville].lat, villes[ville].lon]).addTo(macarte);
    //        }

    //    }
    //}
}

function recupInfoMapByGpx(GPX) {
    $('#lamap').html(' <div id="map" style="height: 300px; margin-top: 50px; position: relative; outline: currentcolor none medium;"></div>');

    var map = L.map('map');
    L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: 'Map data &copy; <a href="http://www.osm.org">OpenStreetMap</a>'
    }).addTo(map);

    var gpx = '../../Content/GPX/' + GPX.trim() + '.css'; // URL to your GPX file or the GPX itself
    console.log(gpx);
    new L.GPX(gpx, { async: true }).on('loaded', function (e) {
        map.fitBounds(e.target.getBounds());
    }).addTo(map);
}