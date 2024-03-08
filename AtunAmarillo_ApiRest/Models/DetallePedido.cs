namespace AtunAmarillo_ApiRest.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
