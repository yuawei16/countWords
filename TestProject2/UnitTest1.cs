using Microsoft.VisualStudio.TestPlatform.TestHost;
using ConsoleApp1;
using Xunit;

namespace TestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void Read_file_Return_Counts()
        {
            // Arrange
            var filePath = @"C:\Users\LeanMaker\source\repos\countWords\TestProject2\my.txt";

            int expectedResult = 6;

            var newProg = new ConsoleApp1.Program(filePath);

            // Act
            string keyWord = newProg.getSearchWord();
            int actualResult = newProg.getCounts(keyWord);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Create_Object_Get_CorrectFilename()
        {
            // Arrange
            var filePath = @"C:\Users\LeanMaker\source\repos\countWords\TestProject2\my.txt";

            String expectedResult = "my";

            var newProg = new ConsoleApp1.Program(filePath);

            // Act
            string actualResult = newProg.getSearchWord();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Give_NonexistentFile_ThrowException()
        {
            // Arrange
            var filePath = @"C:\Users\LeanMaker\source\repos\countWords\TestProject2\myFile.txt";

            // Assert
            Assert.Throws<FileNotFoundException>(() =>
            {
                var newProg = new ConsoleApp1.Program(filePath);
                string keyWord = newProg.getSearchWord();
                newProg.getCounts(keyWord);
            });
        }
    }
}