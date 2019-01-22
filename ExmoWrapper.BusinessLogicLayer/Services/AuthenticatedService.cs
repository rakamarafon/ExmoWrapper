using ExmoWrapper.BusinessLogicLayer.Interfaces;
using ExmoWrapper.Common.DTOs;
using ExmoWrapper.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExmoWrapper.BusinessLogicLayer.Services
{
    public class AuthenticatedService : ExmoServiceBase, IAuthenticatedAPI
    {
        public AuthenticatedService(string key, string secret) : base(key, secret)
        {
          
        }
        public async Task<UserInfoDTO> GetUserInfoAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<OrderCreateDTO> CreateOrder(string currencyPair, decimal quantity, decimal price, OrderType type)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderCancelDTO> CancelOrder(int order_id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserOpenOrdersDTO> GetUserOpenOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<UserTradesDTO> GetUserTradesHistory(string currency_pair, int offset = 0, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public async Task<UserCanceledOrdersDTO> GetUserCanceledOrdersHistory(int offset = 0, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderTradesDTO> GetOrderTradeHistory(int order_id)
        {
            throw new NotImplementedException();
        }

        public async Task<RequiredAmountDTO> GetRequiredAmount(string currency_pair, decimal quantity)
        {
            throw new NotImplementedException();
        }

        public async Task<DepositAddressDTO> GetDepositAddress()
        {
            throw new NotImplementedException();
        }
    }
}
