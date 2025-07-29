// See https://aka.ms/new-console-template for more information

using VendingMachine;

VendingMachine.VendingMachine machine = new AnimalFeedVendingMachine();

Console.Write(machine.Dispense(2.0M));