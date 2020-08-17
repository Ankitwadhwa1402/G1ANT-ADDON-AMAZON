using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.amazon
{

    [Command(Name = "amazon.addcart", Tooltip = "This command is used to add a product in a cart of Amazon .")]
    public class AmazonAddCartCommand : Command
    {
        public AmazonAddCartCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter Amazon Product URL")]
            public TextStructure Url { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.NewTab(arguments.Timeout.Value, arguments.Url?.Value, arguments.NoWait.Value);

                arguments.Search.Value = "add-to-cart-button";
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "hlb-view-cart-announce";
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}