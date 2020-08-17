using G1ANT.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Addon.amazon
{
    [Command(Name = "amazon.logout", Tooltip = "This command is use to closes a web browser in which amazon is opened")]
    public class AmazonLogoutCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public AmazonLogoutCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "nav-item-signout";
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while closing selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}