using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.amazon
{
    [Command(Name = "amazon.search", Tooltip = "This command search any element on amazon")]
    class AmazonSearchCommand : Command
    {
        public AmazonSearchCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Text to be typed")]
            public TextStructure Text { get; set; }

            [Argument(Tooltip = "If set to `true`, the command should wait for a new window to appear after clicking the specified element")]
            public BooleanStructure WaitForNewWindow { get; set; } = new BooleanStructure(false);

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "twotabsearchtextbox";
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.TypeText(arguments.Text.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "nav-input";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value, arguments.WaitForNewWindow.Value);




            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while typing text to element. Text: '{arguments.Text.Value}'. 'Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
