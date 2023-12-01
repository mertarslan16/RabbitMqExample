using System.Text;
using RabbitMQ.Client;

var connectionFactory = new ConnectionFactory(){
    HostName = "localhost",
};

var connection = connectionFactory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare(queue:"hello", durable:false, exclusive:false, autoDelete:false, arguments: null );


var message = "Hello World";
var byteMessage = Encoding.UTF8.GetBytes(message);


channel.BasicPublish(exchange:"", routingKey:"hello", basicProperties:null,body:byteMessage);

System.Console.WriteLine("mesaj gonderildi");

//Console.ReadKey();