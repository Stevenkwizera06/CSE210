## Week 04 Designs

### Program 1: YouTube Videos (Abstraction)

Classes
- Video
  - Attributes: `Title: string`, `Author: string`, `LengthSeconds: int`, `Comments: List<Comment>`
  - Behaviors: `AddComment(Comment)`, `GetCommentCount(): int`, `GetComments(): IReadOnlyList<Comment>`
- Comment
  - Attributes: `AuthorName: string`, `Text: string`
  - Behaviors: `ToString(): string`

Class Diagram (text)
```
Video
  - Title: string
  - Author: string
  - LengthSeconds: int
  - Comments: List<Comment>
  + AddComment(c: Comment)
  + GetCommentCount(): int
  + GetComments(): IReadOnlyList<Comment>

Comment
  - AuthorName: string
  - Text: string
  + ToString(): string
```

Program Flow
1. Create 3–4 `Video` instances.
2. Add 3–4 `Comment` instances to each video.
3. Store the videos in a list.
4. Iterate videos and display details and comments.

### Program 2: Online Ordering (Encapsulation)

Classes
- Address
  - Attributes: `Street: string`, `City: string`, `StateOrProvince: string`, `Country: string`
  - Behaviors: `IsInUSA(): bool`, `FormatMultiline(): string`
- Customer
  - Attributes: `Name: string`, `Address: Address`
  - Behaviors: `IsInUSA(): bool`
- Product
  - Attributes: `Name: string`, `ProductId: string`, `PricePerUnit: decimal`, `Quantity: int`
  - Behaviors: `GetTotalCost(): decimal`
- Order
  - Attributes: `Products: List<Product>`, `Customer: Customer`
  - Behaviors: `AddProduct(Product)`, `CalculateTotal(): decimal`, `GetPackingLabel(): string`, `GetShippingLabel(): string`

Rules
- Shipping cost: $5 (USA) or $35 (international).
- Total = sum(product totals) + shipping.

Program Flow
1. Create 2 customers (one USA, one international).
2. Create products and add them to two orders.
3. For each order: print packing label, shipping label, and total.


