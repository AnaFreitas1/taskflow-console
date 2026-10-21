using System;

var manager = new TaskManager();
bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("=== TaskFlow - Gerenciador de Tarefas ===");
    Console.WriteLine("1. Adicionar Tarefa");
    Console.WriteLine("2. Listar Tarefas");
    Console.WriteLine("3. Concluir Tarefa");
    Console.WriteLine("4. Sair");
    Console.Write("Escolha uma opção: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Digite o título da tarefa: ");
            var title = Console.ReadLine();
            try
            {
                manager.AddTask(title ?? string.Empty);
                Console.WriteLine("Tarefa adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            break;

        case "2":
            Console.WriteLine("\n--- Lista de Tarefas ---");
            foreach (var t in manager.Tasks)
            {
                string status = t.IsCompleted ? "[Concluída]" : "[Pendente]";
                Console.WriteLine($"ID: {t.Id} | {t.Title} {status}");
            }
            break;

        case "3":
            Console.Write("Digite o ID da tarefa a concluir: ");
            if (Guid.TryParse(Console.ReadLine(), out var id))
            {
                bool success = manager.CompleteTask(id);
                Console.WriteLine(success ? "Tarefa concluída com sucesso!" : "Tarefa não encontrada.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            break;

        case "4":
            running = false;
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    if (running)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
