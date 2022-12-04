#### Create Menu Request

```js
POST /hosts/{hostId}/menus
```

```json
{
  "name": "Yummy menu",
  "description": "a menu with yummy food",
  "sections": [
    {
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "name": "Fried pickles",
          "description": "Deep fried pickles"
        }
      ]
    }
  ]
}
```

#### Create Menu Response

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Yummy Menu",
    "description": "A menu with yummy food",
    "averageRating": 4.5,
    "sections": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "id": "00000000-0000-0000-0000-000000000000",
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles"
                }
            ]
        }
    ],
    "hostId": "00000000-0000-0000-0000-000000000000",
    "dinnerIds": [ "00000000-0000-0000-0000-000000000000" ],
    "menuReviewIds": [ "00000000-0000-0000-0000-000000000000" ],
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
```
