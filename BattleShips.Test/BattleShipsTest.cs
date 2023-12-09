namespace BattleShips.Test;


[TestClass]
public class BattleShipsTest
{
    [TestMethod]
    public void PrintShouldEmptyBoard()
    {
      var writer = new StringWriter();
      Console.SetOut(writer);
      BattleShips.Board.print();

      var actual = writer.GetStringBuilder().ToString();

      var expected = @"
 | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
0|   |   |   |   |   |   |   |   |   |   |
1|   |   |   |   |   |   |   |   |   |   |
2|   |   |   |   |   |   |   |   |   |   |
3|   |   |   |   |   |   |   |   |   |   |
4|   |   |   |   |   |   |   |   |   |   |
5|   |   |   |   |   |   |   |   |   |   |
6|   |   |   |   |   |   |   |   |   |   |
7|   |   |   |   |   |   |   |   |   |   |
8|   |   |   |   |   |   |   |   |   |   |
9|   |   |   |   |   |   |   |   |   |   |
";

      Assert.AreEqual(expected, actual);
    }
}

