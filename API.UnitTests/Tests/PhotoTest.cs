using API.DataEntities;
namespace API.UnitTests.DataEntities
{
    public class PhotoTests
    {
        [Fact]
        public void Photo_ShouldHaveDefaultNavigationProperty()
        {
            var photo = new Photo
            {
                Url = "http://example.com/photo.jpg" 
            };
            Assert.Null(photo.AppUser);
        }
        [Fact]
        public void Photo_ShouldSetPropertiesCorrectly()
        {
            var photo = new Photo
            {
                Id = 1,
                Url = "http://example.com/photo.jpg",
                IsMain = true,
                PublicId = "abc123",
                AppUserId = 2
            };
            Assert.Equal(1, photo.Id);
            Assert.Equal("http://example.com/photo.jpg", photo.Url);
            Assert.True(photo.IsMain);
            Assert.Equal("abc123", photo.PublicId);
            Assert.Equal(2, photo.AppUserId);
        }
    }
}