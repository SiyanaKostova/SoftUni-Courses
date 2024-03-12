function printSongs(input) {

    class Song {
        constructor(type, name, time) {
            this.type = type;
            this.name = name;
            this.time = time;
        }
    }

    let songs = [];
    let numberOfSongs = input.shift();
    let typesong = input.pop();

    for (let i = 0; i < numberOfSongs; i++) {
        let [type, name, time] = input[i].split('_');
        let song = new Song(type, name, time);
        songs.push(song);
    }

    if (typesong === 'all') {
        songs.forEach((s) => console.log(s.name));
    } else {
        let filteredSongs = songs.filter((s) => s.type === typesong);
        filteredSongs.forEach((i) => console.log(i.name));
    }
}

printSongs([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']);
printSongs([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']
    );