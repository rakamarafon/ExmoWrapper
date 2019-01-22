using ExmoWrapper.Common.DTOs;
using ExmoWrapper.Common.Enums;
using System.Threading.Tasks;

namespace ExmoWrapper.BusinessLogicLayer.Interfaces
{
    public interface IAuthenticatedAPI
    {
        Task<UserInfoDTO> GetUserInfoAsync();
        Task<OrderCreateDTO> CreateOrder(string currency_pair, decimal quantity, decimal price, OrderType type);
        Task<OrderCancelDTO> CancelOrder(int order_id);
        Task<UserOpenOrdersDTO> GetUserOpenOrders();
        Task<UserTradesDTO> GetUserTradesHistory(string currency_pair, int offset = 0, int limit = 100);
        Task<UserCanceledOrdersDTO> GetUserCanceledOrdersHistory(int offset = 0, int limit = 100);
        Task<OrderTradesDTO> GetOrderTradeHistory(int order_id);
        Task<RequiredAmountDTO> GetRequiredAmount(string currency_pair, decimal quantity);
        Task<DepositAddressDTO> GetDepositAddress();
    }
}
