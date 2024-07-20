using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Model.Commands;
using Model.Commands.Interfaces;
using Model.Validations;

namespace Model
{
    public class CalculateCommandFactory
    {
        private readonly Dictionary<char, Type> _commandTypes;

        public CalculateCommandFactory()
        {
            _commandTypes = new Dictionary<char, Type>();
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            var commandTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetCustomAttribute<CommandOperatorAttribute>() != null).ToList();

            foreach (var commandType in commandTypes)
            {
                var commandOperatorAttribute = commandType.GetCustomAttribute<CommandOperatorAttribute>();
                _commandTypes[commandOperatorAttribute.Operator] = commandType;
            }
        }

        public ICalculateCommand Create(ValidationResult validationResult)
        {
            if (_commandTypes.TryGetValue(validationResult.Operator, out var type))
            {
                return (ICalculateCommand)Activator.CreateInstance(type, validationResult.Operands);
            }

            return null;
        }
    }
}