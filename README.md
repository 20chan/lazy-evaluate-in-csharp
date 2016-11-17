# Lazy Evaluation in C# #

C#에서의 느긋한 계산이 사용되는 다양한 예제를 소개합니다.

## LINQ

두가지 방법으로 로또 숫자를 출력하며 LINQ구문의 느긋한 계산이 사용됨을 보여줍니다.

## InfiniteArgument

`Infinity() = Infinity() + 1` 이라는 스택오버플로우를 발생시키는 코드를 사용하여 `IEnumerable<>` 클래스에서 느긋한 계산이 사용됨을 보여줍니다.

## Lazy<>

Lazy하지 않은 클래스를 Lazy하게 만들어주는 클래스 `System.Lazy<>`의 간단한 예제를 보여줍니다.

## AndOr

&&, || 오퍼레이터에서 사용되는 느긋한 계산을 보여줘 `i == 0 || j++ == 1` 와 같은 코드의 위험성을 보여줍니다.