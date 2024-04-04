// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from Lavanya"

// Defining discriminated union
type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

// Defining record for Director
type Director = {
    name: string
    movies: int
}

// Defining record for Movie
type Movie = {
    name: string
    runLength: int
    genre: Genre
    director: Director
    IMDbRating: float // Corrected the typo here
}

// Creating list of movies
let movies = [
    { name = "King Richard"; runLength = 144; genre = Sport; director = { name = "Reinaldo Marcus Green"; movies = 15 }; IMDbRating = 7.5 }
    { name = "Nightmare Alley"; runLength = 150; genre = Thriller; director = { name = "Guillermo Del Toro"; movies = 22 }; IMDbRating = 7.1 }
    { name = "Dune"; runLength = 155; genre = Fantasy; director = { name = "Denis Villeneuve"; movies = 24 }; IMDbRating = 8.1 }
    { name = "Drive My Car"; runLength = 179; genre = Drama; director = { name = "Ryusuke Hamaguchi"; movies = 16 }; IMDbRating = 7.6 }
    { name = "CODA"; runLength = 111; genre = Drama; director = { name = "Sian Heder"; movies = 9 }; IMDbRating = 8.1 }
    { name = "Belfast"; runLength = 98; genre = Comedy; director = { name = "Kenneth Branagh"; movies = 23 }; IMDbRating = 7.3 }
    { name = "Don't Look Up"; runLength = 138; genre = Comedy; director = { name = "Adam McKay"; movies = 27 }; IMDbRating = 7.2 }
    { name = "Licorice Pizza"; runLength = 133; genre = Comedy; director = { name = "Paul Thomas Anderson"; movies = 49 }; IMDbRating = 7.4 }
]

// Printing the list
movies |> List.iter (fun movie ->
    printfn "Name: %s" movie.name
    printfn "RunLength: %d mins" movie.runLength
    printfn "Genre: %A" movie.genre
    printfn "Director: %s " movie.director.name 
    printfn "Total Movies: %d" movie.director.movies
    printfn "IMDb Rating: %.1f \n" movie.IMDbRating
)



// Probable oscar winners
let probableOscarWinners = List.filter (fun m -> m.IMDbRating > 7.4) movies

printfn "Probable Oscar Winners:"
probableOscarWinners |> List.iter (fun movie ->
    printfn "Name: %s" movie.name
    printfn "RunLength: %d mins" movie.runLength
    printfn "Genre: %A" movie.genre
    printfn "Director: %s" movie.director.name 
    printfn "Total Movies: %d" movie.director.movies
    printfn "IMDb Rating: %.1f" movie.IMDbRating
    printfn ""
)


printfn "\n"

// Run length to hours
let runLength_hrs (runLength: int) =
    let hours = runLength / 60
    let minutes = runLength % 60
    sprintf "%d hours %d mins" hours minutes

let runLengthsInHours = List.map (fun movie -> runLength_hrs movie.runLength) movies

printfn "Run Lengths Converted to hours:"

movies |> List.iter (fun movie ->
    let runLengthHours = runLength_hrs movie.runLength
    printfn "Movie : %s | Director: %s | RunLength(hours): %s" movie.name movie.director.name runLengthHours
)
