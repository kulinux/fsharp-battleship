namespace BattleShips.Test;

using Microsoft.FSharp.Collections;
using static BattleShips.Board;


[TestClass]
public class BattleShipsTest
{

  StringWriter writer = null!;
  TextWriter consoleWriter = null!;

  [TestInitialize]
  public void setup()
  {
    writer = new StringWriter();
    consoleWriter = Console.Out;
    Console.SetOut(writer);
  }

  [TestCleanup]
  public void teardown()
  {
    Console.SetOut(consoleWriter);
  }


  [TestMethod]
  public void PrintShouldEmptyBoard()
  {
    Board.emptyGame().print();

    var actual = writer.GetStringBuilder().ToString();

    var expected = " | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
"0|   |   |   |   |   |   |   |   |   |   |\n" +
"1|   |   |   |   |   |   |   |   |   |   |\n" +
"2|   |   |   |   |   |   |   |   |   |   |\n" +
"3|   |   |   |   |   |   |   |   |   |   |\n" +
"4|   |   |   |   |   |   |   |   |   |   |\n" +
"5|   |   |   |   |   |   |   |   |   |   |\n" +
"6|   |   |   |   |   |   |   |   |   |   |\n" +
"7|   |   |   |   |   |   |   |   |   |   |\n" +
"8|   |   |   |   |   |   |   |   |   |   |\n" +
"9|   |   |   |   |   |   |   |   |   |   |\n";

    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void ShouldPrintASeaFire()
  {
    var game = Board.emptyGame();
    game
      .fire(0, 0)
      .fire(1, 2)
      .print();

    var expected =
    " | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
    "0| o |   |   |   |   |   |   |   |   |   |\n" +
    "1|   |   | o |   |   |   |   |   |   |   |\n" +
    "2|   |   |   |   |   |   |   |   |   |   |\n" +
    "3|   |   |   |   |   |   |   |   |   |   |\n" +
    "4|   |   |   |   |   |   |   |   |   |   |\n" +
    "5|   |   |   |   |   |   |   |   |   |   |\n" +
    "6|   |   |   |   |   |   |   |   |   |   |\n" +
    "7|   |   |   |   |   |   |   |   |   |   |\n" +
    "8|   |   |   |   |   |   |   |   |   |   |\n" +
    "9|   |   |   |   |   |   |   |   |   |   |\n";

    var actual = writer.GetStringBuilder().ToString();

    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void ShouldPrintShips()
  {
    var game = Board.emptyGame();
    var ships = new List<ShipInBoard> { new ShipInBoard(new Coordinate(0, 0), Ship.Gunship) };

    game
      .start(ListModule.OfSeq(ships))
      .print();

    var expected =
    " | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
    "0| g |   |   |   |   |   |   |   |   |   |\n" +
    "1|   |   |   |   |   |   |   |   |   |   |\n" +
    "2|   |   |   |   |   |   |   |   |   |   |\n" +
    "3|   |   |   |   |   |   |   |   |   |   |\n" +
    "4|   |   |   |   |   |   |   |   |   |   |\n" +
    "5|   |   |   |   |   |   |   |   |   |   |\n" +
    "6|   |   |   |   |   |   |   |   |   |   |\n" +
    "7|   |   |   |   |   |   |   |   |   |   |\n" +
    "8|   |   |   |   |   |   |   |   |   |   |\n" +
    "9|   |   |   |   |   |   |   |   |   |   |\n";

    var actual = writer.GetStringBuilder().ToString();

    Assert.AreEqual(expected, actual);
  }
}

