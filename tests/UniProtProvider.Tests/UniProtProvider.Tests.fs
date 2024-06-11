module UniProtProviderTests

open MyNamespace
open NUnit.Framework

[<Test>]
let ``Default constructor should create instance`` () =
    Assert.That("My internal state", Is.EqualTo(MyType().InnerState))

[<Test>]
let ``Constructor with parameter should create instance`` () =
    Assert.That("override", Is.EqualTo(MyType("override").InnerState))

[<Test>]
let ``Method with ReflectedDefinition parameter should get its name`` () =
    let myValue = 2
    Assert.That("myValue", Is.EqualTo(MyType.NameOf(myValue)))

type Generative2 = UniProtProvider.GenerativeProvider<2>
type Generative4 = UniProtProvider.GenerativeProvider<4>

[<Test>]
let ``Can access properties of generative provider 2`` () =
    let obj = Generative2()
    Assert.That(obj.Property1, Is.EqualTo(1))
    Assert.That(obj.Property2, Is.EqualTo(2))

[<Test>]
let ``Can access properties of generative provider 4`` () =
    let obj = Generative4()
    Assert.That(obj.Property1, Is.EqualTo(1))
    Assert.That(obj.Property2, Is.EqualTo(2))
    Assert.That(obj.Property3, Is.EqualTo(3))
    Assert.That(obj.Property4, Is.EqualTo(4s))

[<Test>]
let ``Can use static method properly`` () =
  let res1 = UniProtDemo.Static.Test<"hi">()
  let res2 = UniProtDemo.Static.Test<"there">()
  Assert.That(res1, Is.EqualTo("hi"))
  Assert.That(res2, Is.EqualTo("there"))

