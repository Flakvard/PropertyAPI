# Auth

#### Register

```http
POST {{host}}/auth/register
```


#### Register Request
```json
{
    "firstName": "Marni",
    "lastName": "Falkvard Joensen",
    "email": "marni@mail.com",
    "password": "password123",
}
```

#### Request Response

```json
200 OK
```
```json
{
    "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
    "firstName": "Marni",
    "lastName": "Falkvard Joensen",
    "email": "marni@mail.com",
    "token": "b920b55aa104-db3e-95ff-4075-d89c2d9a"
}
```
#### Login Request
```json
{
    "email": "marni@mail.com",
    "password": "password123",
}
```
#### Login Response
```json
200 OK
```
```json
{
  "id": "208fcc5c-db44-49ed-a020-126d03a73496",
  "firstName": "FirstName",
  "lastName": "LastName",
  "email": "marni@mail.com",
  "token": "token"
}
```