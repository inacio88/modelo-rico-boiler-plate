using Flunt.Notifications;
using Microsoft.VisualBasic;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler : Notifiable<Notification>,
    IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreatePayPalSubscriptionCommand>,
    IHandler<CreateCreditCardSubscriptionCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IEmailService _emailService;

    public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
    {
        _studentRepository = studentRepository;
        _emailService = emailService;
    }
    
    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        //fail fast validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar asssinaura");
        }
        
        // verificar se doc já está cadastrado
        if (_studentRepository.DocumentExists(command.Document))
        {
            AddNotification("Document", "Esse cpf já está em uso");
        }
        // verificar se email já está cadastrado
        if (_studentRepository.EmailExists(command.Email))
        {
            AddNotification("Email", "Esse cpf já está em uso");
        }
        //gerar os vos
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
        
        
        //gerar entidades 
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new BoletoPayment(
            command.BarCode,
            command.BoletoNumber,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            new Document(command.PayerDocument, command.PayerDocumentType),
            address,
            email
        );
        
        // relacionamentos
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);
        
        //agrupar validações
        AddNotifications(name, document, email, address, student, subscription, payment);
        
        //salvar inforamções
        _studentRepository.CreateSubscription(student);
        
        //enviar email de baos vindas
        _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao balta", "sua assinatura foi criada");
        
        // retornar informções
        return new CommandResult(true, "Assinatura realizada com sucesso!");
    }

    public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
    {
        
        // verificar se doc já está cadastrado
        if (_studentRepository.DocumentExists(command.Document))
        {
            AddNotification("Document", "Esse cpf já está em uso");
        }
        // verificar se email já está cadastrado
        if (_studentRepository.EmailExists(command.Email))
        {
            AddNotification("Email", "Esse cpf já está em uso");
        }
        //gerar os vos
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
        
        
        //gerar entidades 
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new PayPalPayment(
            command.TransactionCode,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            new Document(command.PayerDocument, command.PayerDocumentType),
            address,
            email
        );
        
        // relacionamentos
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);
        
        //agrupar validações
        AddNotifications(name, document, email, address, student, subscription, payment);
        
        //salvar inforamções
        _studentRepository.CreateSubscription(student);
        
        //enviar email de baos vindas
        _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao balta", "sua assinatura foi criada");
        
        // retornar informções
        return new CommandResult(true, "Assinatura realizada com sucesso!");
    }

    public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
    {
                
        // verificar se doc já está cadastrado
        if (_studentRepository.DocumentExists(command.Document))
        {
            AddNotification("Document", "Esse cpf já está em uso");
        }
        // verificar se email já está cadastrado
        if (_studentRepository.EmailExists(command.Email))
        {
            AddNotification("Email", "Esse cpf já está em uso");
        }
        //gerar os vos
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
        
        
        //gerar entidades 
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new PayPalPayment(
            command.CardNumber,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            new Document(command.PayerDocument, command.PayerDocumentType),
            address,
            email
        );
        
        // relacionamentos
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);
        
        //agrupar validações
        AddNotifications(name, document, email, address, student, subscription, payment);
        
        //salvar inforamções
        _studentRepository.CreateSubscription(student);
        
        //enviar email de baos vindas
        _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao balta", "sua assinatura foi criada");
        
        // retornar informções
        return new CommandResult(true, "Assinatura realizada com sucesso!");
    }
}