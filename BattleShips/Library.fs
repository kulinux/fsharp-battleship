namespace BattleShips

module Board =

    type Ship =
        | Carrier = 1
        | Destroyer = 2
        | Gunship = 3

    type Coordinates = int * int

    type ShipInBoard = Coordinates * Ship

    type Shots = Coordinates list

    type GameState = ShipInBoard list * Shots

    let private printRow (number: int, shots: Shots) =
        let shotInThisLine =
            shots
            |> List.filter (fun shot -> fst shot = number)
            |> List.map (fun shot -> snd shot)


        let shots =
            [ 0..10 ]
            |> List.map (fun index ->
                match shotInThisLine |> List.contains index with
                | true -> 'o'
                | false -> ' ')


        printfn
            "%d| %c | %c | %c | %c | %c | %c | %c | %c | %c | %c |"
            number
            shots[0]
            shots[1]
            shots[2]
            shots[3]
            shots[4]
            shots[5]
            shots[6]
            shots[7]
            shots[8]
            shots[9]



    let private printGame (state: GameState) =
        let header = """ | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |"""

        printfn "%s" header

        for i in 0..9 do
            printRow (i, snd state)


    type Game(stateIn: GameState) =
        let state = stateIn

        member self.fire(x: int, y: int) : Game =
            let nextState =
                match state with
                | (ships, shots) -> (ships, (x, y) :: shots)

            Game nextState

        member self.print() : unit = printGame state

    let emptyGame () : Game = Game([], [])
