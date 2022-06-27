# Auth

## Register

```js
POST {(host)}/auth/register
```
## Register Request
```json
{
  "firstName": "Torben",
  "lastName": "Tobias",
  "email": "test@mail.com",
  "password": "securePassword123!"
}
```

## Register Response
```js
200 OK
```

```json
{
  "id": "guid",
  "firstName": "Torben",
  "lastName": "Tobias",
  "email": "test@mail.com",
  "token": "generated Token"
}
```