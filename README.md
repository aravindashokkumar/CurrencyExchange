# CurrencyExchange
The following URL is required to get the output: <br/>
<b>GET /api/CurrencyExchanger?source={source-currency}&target={target-currency}&amount={amount-to-convert} </b>

Response is returned with following fields: <br/>
response_message: <br/>
exchange_rate: <br/>
exchange_amount: <br/>


Sample Input: 
```
GET /api/CurrencyExchanger?source=SGD&target=USD&amount=19000
```


Sample Response:
```
<CurrencyExchangeOutput xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.datacontract.org/2004/07/CurrencyExchange.Models">
<script />
<script />
<exchange_amount>14101</exchange_amount>
<exchange_rate>0.742164</exchange_rate>
<response_message i:nil="true" />
</CurrencyExchangeOutput>
```
