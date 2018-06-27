using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EnvironmentRepro.IntegrationTests
{
    public class HomeTests : IClassFixture<WebApplicationFactory<Startup>>
    {
	    private readonly WebApplicationFactory<Startup> _factory;

	    public HomeTests(WebApplicationFactory<Startup> factory)
	    {
		    _factory = factory;
	    }

	    [Fact]
	    public void Environment_variable_should_be_integration_test()
	    {
			Assert.Equal("Staging", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
	    }

	    
	    [Fact]
        public async Task Environment_should_be_set_from_variable()
	    {
		    var client = _factory.CreateClient();
		    var response = await client.GetStringAsync("");
	        Assert.Equal(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), response);
        }
    }
}
