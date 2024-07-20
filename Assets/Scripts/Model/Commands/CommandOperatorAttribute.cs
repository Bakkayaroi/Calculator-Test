using System;

namespace Model.Commands
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class CommandOperatorAttribute : Attribute
    {
        public char Operator { get; }

        public CommandOperatorAttribute(char @operator)
        {
            Operator = @operator;
        }
    }
}