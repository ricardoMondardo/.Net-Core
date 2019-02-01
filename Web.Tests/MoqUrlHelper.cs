using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Tests
{
    public class MoqUrlHelper
    {
        private readonly IUrlHelper _urlHelper;
        public MoqUrlHelper()
        {
            var mockUrlHelper = new Mock<IUrlHelper>(MockBehavior.Strict);
            mockUrlHelper
                .Setup(x => x.Action(It.IsAny<UrlActionContext>()))
                .Returns("callbackUrl")
                .Verifiable();

            mockUrlHelper
                .Setup(m => m.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns("test url");

            _urlHelper = mockUrlHelper.Object;
        }

        public IUrlHelper UrlHelper { get { return _urlHelper; } }

    }
}
