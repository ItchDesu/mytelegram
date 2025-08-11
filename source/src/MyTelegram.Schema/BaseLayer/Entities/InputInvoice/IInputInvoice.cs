// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// An invoice
/// See <a href="https://corefork.telegram.org/constructor/InputInvoice" />
///</summary>
[JsonDerivedType(typeof(TInputInvoiceMessage), nameof(TInputInvoiceMessage))]
[JsonDerivedType(typeof(TInputInvoiceSlug), nameof(TInputInvoiceSlug))]
[JsonDerivedType(typeof(TInputInvoicePremiumGiftCode), nameof(TInputInvoicePremiumGiftCode))]
[JsonDerivedType(typeof(TInputInvoiceStars), nameof(TInputInvoiceStars))]
[JsonDerivedType(typeof(TInputInvoiceChatInviteSubscription), nameof(TInputInvoiceChatInviteSubscription))]
[JsonDerivedType(typeof(TInputInvoiceStarGift), nameof(TInputInvoiceStarGift))]
[JsonDerivedType(typeof(TInputInvoiceStarGiftUpgrade), nameof(TInputInvoiceStarGiftUpgrade))]
[JsonDerivedType(typeof(TInputInvoiceStarGiftTransfer), nameof(TInputInvoiceStarGiftTransfer))]
[JsonDerivedType(typeof(TInputInvoicePremiumGiftStars), nameof(TInputInvoicePremiumGiftStars))]
[JsonDerivedType(typeof(TInputInvoiceBusinessBotTransferStars), nameof(TInputInvoiceBusinessBotTransferStars))]
[JsonDerivedType(typeof(TInputInvoiceStarGiftResale), nameof(TInputInvoiceStarGiftResale))]
public interface IInputInvoice : IObject
{

}
