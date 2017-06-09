﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telegram.Api.Native.TL;
using Telegram.Api.TL;
using Windows.ApplicationModel;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System.Profile;

namespace Telegram.Api.Native.Test
{

    class UserConfiguration : IUserConfiguration
    {
        #region properties
        public string SystemVersion
        {
            get
            {
                string deviceFamilyVersion = AnalyticsInfo.VersionInfo.DeviceFamilyVersion;
                ulong version = ulong.Parse(deviceFamilyVersion);
                ulong major = (version & 0xFFFF000000000000L) >> 48;
                ulong minor = (version & 0x0000FFFF00000000L) >> 32;
                ulong build = (version & 0x00000000FFFF0000L) >> 16;
                ulong revision = version & 0x000000000000FFFFL;
                return $"{major}.{minor}.{build}.{revision}";
            }
        }

        public string AppVersion
        {
            get
            {
                var v = Package.Current.Id.Version;
                return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
            }
        }

        public string Language => Windows.System.UserProfile.GlobalizationPreferences.Languages[0];

        public string DeviceModel
        {
            get
            {
                var info = new EasClientDeviceInformation();
                return string.IsNullOrWhiteSpace(info.SystemProductName) ? info.FriendlyName : info.SystemProductName;
            }
        }
        #endregion

    }


    public class TLTestObject : ITLObject
    {
        public static void Register()
        {
            TLObjectSerializer.RegisterObjectConstructor(0x7F3B18EA, () => new TLInputPeerEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x7DA07EC9, () => new TLInputPeerSelf());
            TLObjectSerializer.RegisterObjectConstructor(0x179BE863, () => new TLInputPeerChat());
            TLObjectSerializer.RegisterObjectConstructor(0x7B8E7DE6, () => new TLInputPeerUser());
            TLObjectSerializer.RegisterObjectConstructor(0x20ADAEF8, () => new TLInputPeerChannel());
            TLObjectSerializer.RegisterObjectConstructor(0xB98886CF, () => new TLInputUserEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xF7C1B13F, () => new TLInputUserSelf());
            TLObjectSerializer.RegisterObjectConstructor(0xD8292816, () => new TLInputUser());
            TLObjectSerializer.RegisterObjectConstructor(0xF392B7F4, () => new TLInputPhoneContact());
            TLObjectSerializer.RegisterObjectConstructor(0xF52FF27F, () => new TLInputFile());
            TLObjectSerializer.RegisterObjectConstructor(0xFA4F0BB5, () => new TLInputFileBig());
            TLObjectSerializer.RegisterObjectConstructor(0x9664F57F, () => new TLInputMediaEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x630C9AF1, () => new TLInputMediaUploadedPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0xE9BFB4F3, () => new TLInputMediaPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0xF9C44144, () => new TLInputMediaGeoPoint());
            TLObjectSerializer.RegisterObjectConstructor(0xA6E45987, () => new TLInputMediaContact());
            TLObjectSerializer.RegisterObjectConstructor(0xD070F1E9, () => new TLInputMediaUploadedDocument());
            TLObjectSerializer.RegisterObjectConstructor(0x50D88CAE, () => new TLInputMediaUploadedThumbDocument());
            TLObjectSerializer.RegisterObjectConstructor(0x1A77F29C, () => new TLInputMediaDocument());
            TLObjectSerializer.RegisterObjectConstructor(0x2827A81A, () => new TLInputMediaVenue());
            TLObjectSerializer.RegisterObjectConstructor(0x4843B0FD, () => new TLInputMediaGifExternal());
            TLObjectSerializer.RegisterObjectConstructor(0xB55F4F18, () => new TLInputMediaPhotoExternal());
            TLObjectSerializer.RegisterObjectConstructor(0xE5E9607C, () => new TLInputMediaDocumentExternal());
            TLObjectSerializer.RegisterObjectConstructor(0xD33F43F3, () => new TLInputMediaGame());
            TLObjectSerializer.RegisterObjectConstructor(0x92153685, () => new TLInputMediaInvoice());
            TLObjectSerializer.RegisterObjectConstructor(0x1CA48F57, () => new TLInputChatPhotoEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x927C55B4, () => new TLInputChatUploadedPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0x8953AD37, () => new TLInputChatPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0xE4C123D6, () => new TLInputGeoPointEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xF3B7ACC9, () => new TLInputGeoPoint());
            TLObjectSerializer.RegisterObjectConstructor(0x1CD7BF0D, () => new TLInputPhotoEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xFB95C6C4, () => new TLInputPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0x14637196, () => new TLInputFileLocation());
            TLObjectSerializer.RegisterObjectConstructor(0xF5235D55, () => new TLInputEncryptedFileLocation());
            TLObjectSerializer.RegisterObjectConstructor(0x430F0724, () => new TLInputDocumentFileLocation());
            TLObjectSerializer.RegisterObjectConstructor(0x770656A8, () => new TLInputAppEvent());
            TLObjectSerializer.RegisterObjectConstructor(0x9DB1BC6D, () => new TLPeerUser());
            TLObjectSerializer.RegisterObjectConstructor(0xBAD0E5BB, () => new TLPeerChat());
            TLObjectSerializer.RegisterObjectConstructor(0xBDDDE532, () => new TLPeerChannel());
            TLObjectSerializer.RegisterObjectConstructor(0xAA963B05, () => new TLStorageFileUnknown());
            TLObjectSerializer.RegisterObjectConstructor(0x40BC6F52, () => new TLStorageFilePartial());
            TLObjectSerializer.RegisterObjectConstructor(0x7EFE0E, () => new TLStorageFileJpeg());
            TLObjectSerializer.RegisterObjectConstructor(0xCAE1AADF, () => new TLStorageFileGif());
            TLObjectSerializer.RegisterObjectConstructor(0xA4F63C0, () => new TLStorageFilePng());
            TLObjectSerializer.RegisterObjectConstructor(0xAE1E508D, () => new TLStorageFilePdf());
            TLObjectSerializer.RegisterObjectConstructor(0x528A0677, () => new TLStorageFileMp3());
            TLObjectSerializer.RegisterObjectConstructor(0x4B09EBBC, () => new TLStorageFileMov());
            TLObjectSerializer.RegisterObjectConstructor(0xB3CEA0E4, () => new TLStorageFileMp4());
            TLObjectSerializer.RegisterObjectConstructor(0x1081464C, () => new TLStorageFileWebp());
            TLObjectSerializer.RegisterObjectConstructor(0x7C596B46, () => new TLFileLocationUnavailable());
            TLObjectSerializer.RegisterObjectConstructor(0x53D69076, () => new TLFileLocation());
            TLObjectSerializer.RegisterObjectConstructor(0x200250BA, () => new TLUserEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x2E13F4C3, () => new TLUser());
            TLObjectSerializer.RegisterObjectConstructor(0x4F11BAE1, () => new TLUserProfilePhotoEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xD559D8C8, () => new TLUserProfilePhoto());
            TLObjectSerializer.RegisterObjectConstructor(0x9D05049, () => new TLUserStatusEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xEDB93949, () => new TLUserStatusOnline());
            TLObjectSerializer.RegisterObjectConstructor(0x8C703F, () => new TLUserStatusOffline());
            TLObjectSerializer.RegisterObjectConstructor(0xE26F42F1, () => new TLUserStatusRecently());
            TLObjectSerializer.RegisterObjectConstructor(0x7BF09FC, () => new TLUserStatusLastWeek());
            TLObjectSerializer.RegisterObjectConstructor(0x77EBC742, () => new TLUserStatusLastMonth());
            TLObjectSerializer.RegisterObjectConstructor(0x9BA2D800, () => new TLChatEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xD91CDD54, () => new TLChat());
            TLObjectSerializer.RegisterObjectConstructor(0x7328BDB, () => new TLChatForbidden());
            TLObjectSerializer.RegisterObjectConstructor(0xA14DCA52, () => new TLChannel());
            TLObjectSerializer.RegisterObjectConstructor(0x8537784F, () => new TLChannelForbidden());
            TLObjectSerializer.RegisterObjectConstructor(0x2E02A614, () => new TLChatFull());
            TLObjectSerializer.RegisterObjectConstructor(0xC3D5512F, () => new TLChannelFull());
            TLObjectSerializer.RegisterObjectConstructor(0xC8D7493E, () => new TLChatParticipant());
            TLObjectSerializer.RegisterObjectConstructor(0xDA13538A, () => new TLChatParticipantCreator());
            TLObjectSerializer.RegisterObjectConstructor(0xE2D6E436, () => new TLChatParticipantAdmin());
            TLObjectSerializer.RegisterObjectConstructor(0xFC900C2B, () => new TLChatParticipantsForbidden());
            TLObjectSerializer.RegisterObjectConstructor(0x3F460FED, () => new TLChatParticipants());
            TLObjectSerializer.RegisterObjectConstructor(0x37C1011C, () => new TLChatPhotoEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x6153276A, () => new TLChatPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0x83E5DE54, () => new TLMessageEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x3DED6320, () => new TLMessageMediaEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x3D8CE53D, () => new TLMessageMediaPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0x56E0D474, () => new TLMessageMediaGeo());
            TLObjectSerializer.RegisterObjectConstructor(0x5E7D2F39, () => new TLMessageMediaContact());
            TLObjectSerializer.RegisterObjectConstructor(0x9F84F49E, () => new TLMessageMediaUnsupported());
            TLObjectSerializer.RegisterObjectConstructor(0xF3E02EA8, () => new TLMessageMediaDocument());
            TLObjectSerializer.RegisterObjectConstructor(0xA32DD600, () => new TLMessageMediaWebPage());
            TLObjectSerializer.RegisterObjectConstructor(0x7912B71F, () => new TLMessageMediaVenue());
            TLObjectSerializer.RegisterObjectConstructor(0xFDB19008, () => new TLMessageMediaGame());
            TLObjectSerializer.RegisterObjectConstructor(0x84551347, () => new TLMessageMediaInvoice());
            TLObjectSerializer.RegisterObjectConstructor(0xB6AEF7B0, () => new TLMessageActionEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xA6638B9A, () => new TLMessageActionChatCreate());
            TLObjectSerializer.RegisterObjectConstructor(0xB5A1CE5A, () => new TLMessageActionChatEditTitle());
            TLObjectSerializer.RegisterObjectConstructor(0x7FCB13A8, () => new TLMessageActionChatEditPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0x95E3FBEF, () => new TLMessageActionChatDeletePhoto());
            TLObjectSerializer.RegisterObjectConstructor(0x488A7337, () => new TLMessageActionChatAddUser());
            TLObjectSerializer.RegisterObjectConstructor(0xB2AE9B0C, () => new TLMessageActionChatDeleteUser());
            TLObjectSerializer.RegisterObjectConstructor(0xF89CF5E8, () => new TLMessageActionChatJoinedByLink());
            TLObjectSerializer.RegisterObjectConstructor(0x95D2AC92, () => new TLMessageActionChannelCreate());
            TLObjectSerializer.RegisterObjectConstructor(0x51BDB021, () => new TLMessageActionChatMigrateTo());
            TLObjectSerializer.RegisterObjectConstructor(0xB055EAEE, () => new TLMessageActionChannelMigrateFrom());
            TLObjectSerializer.RegisterObjectConstructor(0x94BD38ED, () => new TLMessageActionPinMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x9FBAB604, () => new TLMessageActionHistoryClear());
            TLObjectSerializer.RegisterObjectConstructor(0x92A72876, () => new TLMessageActionGameScore());
            TLObjectSerializer.RegisterObjectConstructor(0x8F31B327, () => new TLMessageActionPaymentSentMe());
            TLObjectSerializer.RegisterObjectConstructor(0x40699CD0, () => new TLMessageActionPaymentSent());
            TLObjectSerializer.RegisterObjectConstructor(0x80E11A7F, () => new TLMessageActionPhoneCall());
            TLObjectSerializer.RegisterObjectConstructor(0x66FFBA14, () => new TLDialog());
            TLObjectSerializer.RegisterObjectConstructor(0x2331B22D, () => new TLPhotoEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x9288DD29, () => new TLPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0xE17E23C, () => new TLPhotoSizeEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x77BFB61B, () => new TLPhotoSize());
            TLObjectSerializer.RegisterObjectConstructor(0xE9A734FA, () => new TLPhotoCachedSize());
            TLObjectSerializer.RegisterObjectConstructor(0x1117DD5F, () => new TLGeoPointEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x2049D70C, () => new TLGeoPoint());
            TLObjectSerializer.RegisterObjectConstructor(0x811EA28E, () => new TLAuthCheckedPhone());
            TLObjectSerializer.RegisterObjectConstructor(0x5E002502, () => new TLAuthSentCode());
            TLObjectSerializer.RegisterObjectConstructor(0xCD050916, () => new TLAuthAuthorization());
            //TLObjectSerializer.RegisterObjectConstructor(0xDF969C2D, () => new TLAuthExportedAuthorization());
            TLObjectSerializer.RegisterObjectConstructor(0xB8BC5B0C, () => new TLInputNotifyPeer());
            TLObjectSerializer.RegisterObjectConstructor(0x193B4417, () => new TLInputNotifyUsers());
            TLObjectSerializer.RegisterObjectConstructor(0x4A95E84E, () => new TLInputNotifyChats());
            TLObjectSerializer.RegisterObjectConstructor(0xA429B886, () => new TLInputNotifyAll());
            TLObjectSerializer.RegisterObjectConstructor(0xF03064D8, () => new TLInputPeerNotifyEventsEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xE86A2C74, () => new TLInputPeerNotifyEventsAll());
            TLObjectSerializer.RegisterObjectConstructor(0x38935EB2, () => new TLInputPeerNotifySettings());
            TLObjectSerializer.RegisterObjectConstructor(0xADD53CB3, () => new TLPeerNotifyEventsEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x6D1DED88, () => new TLPeerNotifyEventsAll());
            TLObjectSerializer.RegisterObjectConstructor(0x70A68512, () => new TLPeerNotifySettingsEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x9ACDA4C0, () => new TLPeerNotifySettings());
            TLObjectSerializer.RegisterObjectConstructor(0x818426CD, () => new TLPeerSettings());
            TLObjectSerializer.RegisterObjectConstructor(0xCCB03657, () => new TLWallPaper());
            TLObjectSerializer.RegisterObjectConstructor(0x63117F24, () => new TLWallPaperSolid());
            TLObjectSerializer.RegisterObjectConstructor(0x58DBCAB8, () => new TLInputReportReasonSpam());
            TLObjectSerializer.RegisterObjectConstructor(0x1E22C78D, () => new TLInputReportReasonViolence());
            TLObjectSerializer.RegisterObjectConstructor(0x2E59D922, () => new TLInputReportReasonPornography());
            TLObjectSerializer.RegisterObjectConstructor(0xE1746D0A, () => new TLInputReportReasonOther());
            TLObjectSerializer.RegisterObjectConstructor(0xF220F3F, () => new TLUserFull());
            TLObjectSerializer.RegisterObjectConstructor(0xF911C994, () => new TLContact());
            TLObjectSerializer.RegisterObjectConstructor(0xD0028438, () => new TLImportedContact());
            TLObjectSerializer.RegisterObjectConstructor(0x561BC879, () => new TLContactBlocked());
            TLObjectSerializer.RegisterObjectConstructor(0xD3680C61, () => new TLContactStatus());
            TLObjectSerializer.RegisterObjectConstructor(0x3ACE484C, () => new TLContactsLink());
            TLObjectSerializer.RegisterObjectConstructor(0xB74BA9D2, () => new TLContactsContactsNotModified());
            TLObjectSerializer.RegisterObjectConstructor(0x6F8B8CB2, () => new TLContactsContacts());
            TLObjectSerializer.RegisterObjectConstructor(0xAD524315, () => new TLContactsImportedContacts());
            TLObjectSerializer.RegisterObjectConstructor(0x1C138D15, () => new TLContactsBlocked());
            TLObjectSerializer.RegisterObjectConstructor(0x900802A1, () => new TLContactsBlockedSlice());
            TLObjectSerializer.RegisterObjectConstructor(0x15BA6C40, () => new TLMessagesDialogs());
            TLObjectSerializer.RegisterObjectConstructor(0x71E094F3, () => new TLMessagesDialogsSlice());
            TLObjectSerializer.RegisterObjectConstructor(0x8C718E87, () => new TLMessagesMessages());
            TLObjectSerializer.RegisterObjectConstructor(0xB446AE3, () => new TLMessagesMessagesSlice());
            TLObjectSerializer.RegisterObjectConstructor(0x99262E37, () => new TLMessagesChannelMessages());
            TLObjectSerializer.RegisterObjectConstructor(0x64FF9FD5, () => new TLMessagesChats());
            TLObjectSerializer.RegisterObjectConstructor(0x9CD81144, () => new TLMessagesChatsSlice());
            TLObjectSerializer.RegisterObjectConstructor(0xE5D7D19C, () => new TLMessagesChatFull());
            TLObjectSerializer.RegisterObjectConstructor(0xB45C69D1, () => new TLMessagesAffectedHistory());
            TLObjectSerializer.RegisterObjectConstructor(0x57E2F66C, () => new TLInputMessagesFilterEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x9609A51C, () => new TLInputMessagesFilterPhotos());
            TLObjectSerializer.RegisterObjectConstructor(0x9FC00E65, () => new TLInputMessagesFilterVideo());
            TLObjectSerializer.RegisterObjectConstructor(0x56E9F0E4, () => new TLInputMessagesFilterPhotoVideo());
            TLObjectSerializer.RegisterObjectConstructor(0xD95E73BB, () => new TLInputMessagesFilterPhotoVideoDocuments());
            TLObjectSerializer.RegisterObjectConstructor(0x9EDDF188, () => new TLInputMessagesFilterDocument());
            TLObjectSerializer.RegisterObjectConstructor(0x7EF0DD87, () => new TLInputMessagesFilterUrl());
            TLObjectSerializer.RegisterObjectConstructor(0xFFC86587, () => new TLInputMessagesFilterGif());
            TLObjectSerializer.RegisterObjectConstructor(0x50F5C392, () => new TLInputMessagesFilterVoice());
            TLObjectSerializer.RegisterObjectConstructor(0x3751B49E, () => new TLInputMessagesFilterMusic());
            TLObjectSerializer.RegisterObjectConstructor(0x3A20ECB8, () => new TLInputMessagesFilterChatPhotos());
            TLObjectSerializer.RegisterObjectConstructor(0x80C99768, () => new TLInputMessagesFilterPhoneCalls());
            TLObjectSerializer.RegisterObjectConstructor(0x7A7C17A4, () => new TLInputMessagesFilterRoundVoice());
            TLObjectSerializer.RegisterObjectConstructor(0xB549DA53, () => new TLInputMessagesFilterRoundVideo());
            TLObjectSerializer.RegisterObjectConstructor(0x1F2B0AFD, () => new TLUpdateNewMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x4E90BFD6, () => new TLUpdateMessageID());
            TLObjectSerializer.RegisterObjectConstructor(0xA20DB0E5, () => new TLUpdateDeleteMessages());
            TLObjectSerializer.RegisterObjectConstructor(0x5C486927, () => new TLUpdateUserTyping());
            TLObjectSerializer.RegisterObjectConstructor(0x9A65EA1F, () => new TLUpdateChatUserTyping());
            TLObjectSerializer.RegisterObjectConstructor(0x7761198, () => new TLUpdateChatParticipants());
            TLObjectSerializer.RegisterObjectConstructor(0x1BFBD823, () => new TLUpdateUserStatus());
            TLObjectSerializer.RegisterObjectConstructor(0xA7332B73, () => new TLUpdateUserName());
            TLObjectSerializer.RegisterObjectConstructor(0x95313B0C, () => new TLUpdateUserPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0x2575BBB9, () => new TLUpdateContactRegistered());
            TLObjectSerializer.RegisterObjectConstructor(0x9D2E67C5, () => new TLUpdateContactLink());
            TLObjectSerializer.RegisterObjectConstructor(0x12BCBD9A, () => new TLUpdateNewEncryptedMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x1710F156, () => new TLUpdateEncryptedChatTyping());
            TLObjectSerializer.RegisterObjectConstructor(0xB4A2E88D, () => new TLUpdateEncryption());
            TLObjectSerializer.RegisterObjectConstructor(0x38FE25B7, () => new TLUpdateEncryptedMessagesRead());
            TLObjectSerializer.RegisterObjectConstructor(0xEA4B0E5C, () => new TLUpdateChatParticipantAdd());
            TLObjectSerializer.RegisterObjectConstructor(0x6E5F8C22, () => new TLUpdateChatParticipantDelete());
            TLObjectSerializer.RegisterObjectConstructor(0x8E5E9873, () => new TLUpdateDCOptions());
            TLObjectSerializer.RegisterObjectConstructor(0x80ECE81A, () => new TLUpdateUserBlocked());
            TLObjectSerializer.RegisterObjectConstructor(0xBEC268EF, () => new TLUpdateNotifySettings());
            TLObjectSerializer.RegisterObjectConstructor(0xEBE46819, () => new TLUpdateServiceNotification());
            TLObjectSerializer.RegisterObjectConstructor(0xEE3B272A, () => new TLUpdatePrivacy());
            TLObjectSerializer.RegisterObjectConstructor(0x12B9417B, () => new TLUpdateUserPhone());
            TLObjectSerializer.RegisterObjectConstructor(0x9961FD5C, () => new TLUpdateReadHistoryInbox());
            TLObjectSerializer.RegisterObjectConstructor(0x2F2F21BF, () => new TLUpdateReadHistoryOutbox());
            TLObjectSerializer.RegisterObjectConstructor(0x7F891213, () => new TLUpdateWebPage());
            TLObjectSerializer.RegisterObjectConstructor(0x68C13933, () => new TLUpdateReadMessagesContents());
            TLObjectSerializer.RegisterObjectConstructor(0xEB0467FB, () => new TLUpdateChannelTooLong());
            TLObjectSerializer.RegisterObjectConstructor(0xB6D45656, () => new TLUpdateChannel());
            TLObjectSerializer.RegisterObjectConstructor(0x62BA04D9, () => new TLUpdateNewChannelMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x4214F37F, () => new TLUpdateReadChannelInbox());
            TLObjectSerializer.RegisterObjectConstructor(0xC37521C9, () => new TLUpdateDeleteChannelMessages());
            TLObjectSerializer.RegisterObjectConstructor(0x98A12B4B, () => new TLUpdateChannelMessageViews());
            TLObjectSerializer.RegisterObjectConstructor(0x6E947941, () => new TLUpdateChatAdmins());
            TLObjectSerializer.RegisterObjectConstructor(0xB6901959, () => new TLUpdateChatParticipantAdmin());
            TLObjectSerializer.RegisterObjectConstructor(0x688A30AA, () => new TLUpdateNewStickerSet());
            TLObjectSerializer.RegisterObjectConstructor(0xBB2D201, () => new TLUpdateStickerSetsOrder());
            TLObjectSerializer.RegisterObjectConstructor(0x43AE3DEC, () => new TLUpdateStickerSets());
            TLObjectSerializer.RegisterObjectConstructor(0x9375341E, () => new TLUpdateSavedGifs());
            TLObjectSerializer.RegisterObjectConstructor(0x54826690, () => new TLUpdateBotInlineQuery());
            TLObjectSerializer.RegisterObjectConstructor(0xE48F964, () => new TLUpdateBotInlineSend());
            TLObjectSerializer.RegisterObjectConstructor(0x1B3F4DF7, () => new TLUpdateEditChannelMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x98592475, () => new TLUpdateChannelPinnedMessage());
            TLObjectSerializer.RegisterObjectConstructor(0xE73547E1, () => new TLUpdateBotCallbackQuery());
            TLObjectSerializer.RegisterObjectConstructor(0xE40370A3, () => new TLUpdateEditMessage());
            TLObjectSerializer.RegisterObjectConstructor(0xF9D27A5A, () => new TLUpdateInlineBotCallbackQuery());
            TLObjectSerializer.RegisterObjectConstructor(0x25D6C9C7, () => new TLUpdateReadChannelOutbox());
            TLObjectSerializer.RegisterObjectConstructor(0xEE2BB969, () => new TLUpdateDraftMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x571D2742, () => new TLUpdateReadFeaturedStickers());
            TLObjectSerializer.RegisterObjectConstructor(0x9A422C20, () => new TLUpdateRecentStickers());
            TLObjectSerializer.RegisterObjectConstructor(0xA229DD06, () => new TLUpdateConfig());
            TLObjectSerializer.RegisterObjectConstructor(0x3354678F, () => new TLUpdatePtsChanged());
            TLObjectSerializer.RegisterObjectConstructor(0x40771900, () => new TLUpdateChannelWebPage());
            TLObjectSerializer.RegisterObjectConstructor(0xD711A2CC, () => new TLUpdateDialogPinned());
            TLObjectSerializer.RegisterObjectConstructor(0xD8CAF68D, () => new TLUpdatePinnedDialogs());
            TLObjectSerializer.RegisterObjectConstructor(0x8317C0C3, () => new TLUpdateBotWebhookJSON());
            TLObjectSerializer.RegisterObjectConstructor(0x9B9240A6, () => new TLUpdateBotWebhookJSONQuery());
            TLObjectSerializer.RegisterObjectConstructor(0xE0CDC940, () => new TLUpdateBotShippingQuery());
            TLObjectSerializer.RegisterObjectConstructor(0x5D2F3AA9, () => new TLUpdateBotPrecheckoutQuery());
            TLObjectSerializer.RegisterObjectConstructor(0xAB0F6B1E, () => new TLUpdatePhoneCall());
            TLObjectSerializer.RegisterObjectConstructor(0xA56C2A3E, () => new TLUpdatesState());
            TLObjectSerializer.RegisterObjectConstructor(0x5D75A138, () => new TLUpdatesDifferenceEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xF49CA0, () => new TLUpdatesDifference());
            TLObjectSerializer.RegisterObjectConstructor(0xA8FB1981, () => new TLUpdatesDifferenceSlice());
            TLObjectSerializer.RegisterObjectConstructor(0x4AFE8F6D, () => new TLUpdatesDifferenceTooLong());
            TLObjectSerializer.RegisterObjectConstructor(0xE317AF7E, () => new TLUpdatesTooLong());
            TLObjectSerializer.RegisterObjectConstructor(0x914FBF11, () => new TLUpdateShortMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x16812688, () => new TLUpdateShortChatMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x78D4DEC1, () => new TLUpdateShort());
            TLObjectSerializer.RegisterObjectConstructor(0x725B04C3, () => new TLUpdatesCombined());
            TLObjectSerializer.RegisterObjectConstructor(0x74AE4240, () => new TLUpdates());
            TLObjectSerializer.RegisterObjectConstructor(0x11F1331C, () => new TLUpdateShortSentMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x8DCA6AA5, () => new TLPhotosPhotos());
            TLObjectSerializer.RegisterObjectConstructor(0x15051F54, () => new TLPhotosPhotosSlice());
            TLObjectSerializer.RegisterObjectConstructor(0x20212CA8, () => new TLPhotosPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0x96A18D5, () => new TLUploadFile());
            TLObjectSerializer.RegisterObjectConstructor(0x1508485A, () => new TLUploadFileCdnRedirect());
            TLObjectSerializer.RegisterObjectConstructor(0x8E1A1775, () => new TLNearestDC());
            TLObjectSerializer.RegisterObjectConstructor(0x8987F311, () => new TLHelpAppUpdate());
            TLObjectSerializer.RegisterObjectConstructor(0xC45A6536, () => new TLHelpNoAppUpdate());
            TLObjectSerializer.RegisterObjectConstructor(0x18CB9F78, () => new TLHelpInviteText());
            TLObjectSerializer.RegisterObjectConstructor(0xAB7EC0A0, () => new TLEncryptedChatEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x3BF703DC, () => new TLEncryptedChatWaiting());
            TLObjectSerializer.RegisterObjectConstructor(0xC878527E, () => new TLEncryptedChatRequested());
            TLObjectSerializer.RegisterObjectConstructor(0xFA56CE36, () => new TLEncryptedChat());
            TLObjectSerializer.RegisterObjectConstructor(0x13D6DD27, () => new TLEncryptedChatDiscarded());
            TLObjectSerializer.RegisterObjectConstructor(0xF141B5E1, () => new TLInputEncryptedChat());
            TLObjectSerializer.RegisterObjectConstructor(0xC21F497E, () => new TLEncryptedFileEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x4A70994C, () => new TLEncryptedFile());
            TLObjectSerializer.RegisterObjectConstructor(0x1837C364, () => new TLInputEncryptedFileEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x64BD0306, () => new TLInputEncryptedFileUploaded());
            TLObjectSerializer.RegisterObjectConstructor(0x5A17B5E5, () => new TLInputEncryptedFile());
            TLObjectSerializer.RegisterObjectConstructor(0x2DC173C8, () => new TLInputEncryptedFileBigUploaded());
            TLObjectSerializer.RegisterObjectConstructor(0xED18C118, () => new TLEncryptedMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x23734B06, () => new TLEncryptedMessageService());
            TLObjectSerializer.RegisterObjectConstructor(0xC0E24635, () => new TLMessagesDHConfigNotModified());
            TLObjectSerializer.RegisterObjectConstructor(0x2C221EDD, () => new TLMessagesDHConfig());
            TLObjectSerializer.RegisterObjectConstructor(0x560F8935, () => new TLMessagesSentEncryptedMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x9493FF32, () => new TLMessagesSentEncryptedFile());
            TLObjectSerializer.RegisterObjectConstructor(0x72F0EAAE, () => new TLInputDocumentEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x18798952, () => new TLInputDocument());
            TLObjectSerializer.RegisterObjectConstructor(0x36F8C871, () => new TLDocumentEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x87232BC7, () => new TLDocument());
            TLObjectSerializer.RegisterObjectConstructor(0x17C6B5F6, () => new TLHelpSupport());
            TLObjectSerializer.RegisterObjectConstructor(0x9FD40BD8, () => new TLNotifyPeer());
            TLObjectSerializer.RegisterObjectConstructor(0xB4C83B4C, () => new TLNotifyUsers());
            TLObjectSerializer.RegisterObjectConstructor(0xC007CEC3, () => new TLNotifyChats());
            TLObjectSerializer.RegisterObjectConstructor(0x74D07C60, () => new TLNotifyAll());
            TLObjectSerializer.RegisterObjectConstructor(0x16BF744E, () => new TLSendMessageTypingAction());
            TLObjectSerializer.RegisterObjectConstructor(0xFD5EC8F5, () => new TLSendMessageCancelAction());
            TLObjectSerializer.RegisterObjectConstructor(0xA187D66F, () => new TLSendMessageRecordVideoAction());
            TLObjectSerializer.RegisterObjectConstructor(0xE9763AEC, () => new TLSendMessageUploadVideoAction());
            TLObjectSerializer.RegisterObjectConstructor(0xD52F73F7, () => new TLSendMessageRecordAudioAction());
            TLObjectSerializer.RegisterObjectConstructor(0xF351D7AB, () => new TLSendMessageUploadAudioAction());
            TLObjectSerializer.RegisterObjectConstructor(0xD1D34A26, () => new TLSendMessageUploadPhotoAction());
            TLObjectSerializer.RegisterObjectConstructor(0xAA0CD9E4, () => new TLSendMessageUploadDocumentAction());
            TLObjectSerializer.RegisterObjectConstructor(0x176F8BA1, () => new TLSendMessageGeoLocationAction());
            TLObjectSerializer.RegisterObjectConstructor(0x628CBC6F, () => new TLSendMessageChooseContactAction());
            TLObjectSerializer.RegisterObjectConstructor(0xDD6A8F48, () => new TLSendMessageGamePlayAction());
            TLObjectSerializer.RegisterObjectConstructor(0x88F27FBC, () => new TLSendMessageRecordRoundAction());
            TLObjectSerializer.RegisterObjectConstructor(0x243E1C66, () => new TLSendMessageUploadRoundAction());
            TLObjectSerializer.RegisterObjectConstructor(0x1AA1F784, () => new TLContactsFound());
            TLObjectSerializer.RegisterObjectConstructor(0x4F96CB18, () => new TLInputPrivacyKeyStatusTimestamp());
            TLObjectSerializer.RegisterObjectConstructor(0xBDFB0426, () => new TLInputPrivacyKeyChatInvite());
            TLObjectSerializer.RegisterObjectConstructor(0xFABADC5F, () => new TLInputPrivacyKeyPhoneCall());
            TLObjectSerializer.RegisterObjectConstructor(0xBC2EAB30, () => new TLPrivacyKeyStatusTimestamp());
            TLObjectSerializer.RegisterObjectConstructor(0x500E6DFA, () => new TLPrivacyKeyChatInvite());
            TLObjectSerializer.RegisterObjectConstructor(0x3D662B7B, () => new TLPrivacyKeyPhoneCall());
            TLObjectSerializer.RegisterObjectConstructor(0xD09E07B, () => new TLInputPrivacyValueAllowContacts());
            TLObjectSerializer.RegisterObjectConstructor(0x184B35CE, () => new TLInputPrivacyValueAllowAll());
            TLObjectSerializer.RegisterObjectConstructor(0x131CC67F, () => new TLInputPrivacyValueAllowUsers());
            TLObjectSerializer.RegisterObjectConstructor(0xBA52007, () => new TLInputPrivacyValueDisallowContacts());
            TLObjectSerializer.RegisterObjectConstructor(0xD66B66C9, () => new TLInputPrivacyValueDisallowAll());
            TLObjectSerializer.RegisterObjectConstructor(0x90110467, () => new TLInputPrivacyValueDisallowUsers());
            TLObjectSerializer.RegisterObjectConstructor(0xFFFE1BAC, () => new TLPrivacyValueAllowContacts());
            TLObjectSerializer.RegisterObjectConstructor(0x65427B82, () => new TLPrivacyValueAllowAll());
            TLObjectSerializer.RegisterObjectConstructor(0x4D5BBE0C, () => new TLPrivacyValueAllowUsers());
            TLObjectSerializer.RegisterObjectConstructor(0xF888FA1A, () => new TLPrivacyValueDisallowContacts());
            TLObjectSerializer.RegisterObjectConstructor(0x8B73E763, () => new TLPrivacyValueDisallowAll());
            TLObjectSerializer.RegisterObjectConstructor(0xC7F49B7, () => new TLPrivacyValueDisallowUsers());
            TLObjectSerializer.RegisterObjectConstructor(0x554ABB6F, () => new TLAccountPrivacyRules());
            TLObjectSerializer.RegisterObjectConstructor(0xB8D0AFDF, () => new TLAccountDaysTTL());
            TLObjectSerializer.RegisterObjectConstructor(0x6C37C15C, () => new TLDocumentAttributeImageSize());
            TLObjectSerializer.RegisterObjectConstructor(0x11B58939, () => new TLDocumentAttributeAnimated());
            TLObjectSerializer.RegisterObjectConstructor(0x6319D612, () => new TLDocumentAttributeSticker());
            TLObjectSerializer.RegisterObjectConstructor(0xEF02CE6, () => new TLDocumentAttributeVideo());
            TLObjectSerializer.RegisterObjectConstructor(0x9852F9C6, () => new TLDocumentAttributeAudio());
            TLObjectSerializer.RegisterObjectConstructor(0x15590068, () => new TLDocumentAttributeFilename());
            TLObjectSerializer.RegisterObjectConstructor(0x9801D2F7, () => new TLDocumentAttributeHasStickers());
            TLObjectSerializer.RegisterObjectConstructor(0xF1749A22, () => new TLMessagesStickersNotModified());
            TLObjectSerializer.RegisterObjectConstructor(0x8A8ECD32, () => new TLMessagesStickers());
            TLObjectSerializer.RegisterObjectConstructor(0x12B299D4, () => new TLStickerPack());
            TLObjectSerializer.RegisterObjectConstructor(0xE86602C3, () => new TLMessagesAllStickersNotModified());
            TLObjectSerializer.RegisterObjectConstructor(0xEDFD405F, () => new TLMessagesAllStickers());
            TLObjectSerializer.RegisterObjectConstructor(0x84D19185, () => new TLMessagesAffectedMessages());
            TLObjectSerializer.RegisterObjectConstructor(0x5F4F9247, () => new TLContactLinkUnknown());
            TLObjectSerializer.RegisterObjectConstructor(0xFEEDD3AD, () => new TLContactLinkNone());
            TLObjectSerializer.RegisterObjectConstructor(0x268F3F59, () => new TLContactLinkHasPhone());
            TLObjectSerializer.RegisterObjectConstructor(0xD502C2D0, () => new TLContactLinkContact());
            TLObjectSerializer.RegisterObjectConstructor(0xEB1477E8, () => new TLWebPageEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xC586DA1C, () => new TLWebPagePending());
            TLObjectSerializer.RegisterObjectConstructor(0x5F07B4BC, () => new TLWebPage());
            TLObjectSerializer.RegisterObjectConstructor(0x85849473, () => new TLWebPageNotModified());
            TLObjectSerializer.RegisterObjectConstructor(0x7BF2E6F6, () => new TLAuthorization());
            TLObjectSerializer.RegisterObjectConstructor(0x1250ABDE, () => new TLAccountAuthorizations());
            TLObjectSerializer.RegisterObjectConstructor(0x96DABC18, () => new TLAccountNoPassword());
            TLObjectSerializer.RegisterObjectConstructor(0x7C18141C, () => new TLAccountPassword());
            TLObjectSerializer.RegisterObjectConstructor(0xB7B72AB3, () => new TLAccountPasswordSettings());
            TLObjectSerializer.RegisterObjectConstructor(0x86916DEB, () => new TLAccountPasswordInputSettings());
            TLObjectSerializer.RegisterObjectConstructor(0x137948A5, () => new TLAuthPasswordRecovery());
            TLObjectSerializer.RegisterObjectConstructor(0xA384B779, () => new TLReceivedNotifyMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x69DF3769, () => new TLChatInviteEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xFC2E05BC, () => new TLChatInviteExported());
            TLObjectSerializer.RegisterObjectConstructor(0x5A686D7C, () => new TLChatInviteAlready());
            TLObjectSerializer.RegisterObjectConstructor(0xDB74F558, () => new TLChatInvite());
            TLObjectSerializer.RegisterObjectConstructor(0xFFB62B95, () => new TLInputStickerSetEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x9DE7A269, () => new TLInputStickerSetID());
            TLObjectSerializer.RegisterObjectConstructor(0x861CC8A0, () => new TLInputStickerSetShortName());
            TLObjectSerializer.RegisterObjectConstructor(0xCD303B41, () => new TLStickerSet());
            TLObjectSerializer.RegisterObjectConstructor(0xB60A24A6, () => new TLMessagesStickerSet());
            TLObjectSerializer.RegisterObjectConstructor(0xC27AC8C7, () => new TLBotCommand());
            TLObjectSerializer.RegisterObjectConstructor(0x98E81D3A, () => new TLBotInfo());
            TLObjectSerializer.RegisterObjectConstructor(0xA2FA4880, () => new TLKeyboardButton());
            TLObjectSerializer.RegisterObjectConstructor(0x258AFF05, () => new TLKeyboardButtonUrl());
            TLObjectSerializer.RegisterObjectConstructor(0x683A5E46, () => new TLKeyboardButtonCallback());
            TLObjectSerializer.RegisterObjectConstructor(0xB16A6C29, () => new TLKeyboardButtonRequestPhone());
            TLObjectSerializer.RegisterObjectConstructor(0xFC796B3F, () => new TLKeyboardButtonRequestGeoLocation());
            TLObjectSerializer.RegisterObjectConstructor(0x568A748, () => new TLKeyboardButtonSwitchInline());
            TLObjectSerializer.RegisterObjectConstructor(0x50F41CCF, () => new TLKeyboardButtonGame());
            TLObjectSerializer.RegisterObjectConstructor(0xAFD93FBB, () => new TLKeyboardButtonBuy());
            TLObjectSerializer.RegisterObjectConstructor(0x77608B83, () => new TLKeyboardButtonRow());
            TLObjectSerializer.RegisterObjectConstructor(0xA03E5B85, () => new TLReplyKeyboardHide());
            TLObjectSerializer.RegisterObjectConstructor(0xF4108AA0, () => new TLReplyKeyboardForceReply());
            TLObjectSerializer.RegisterObjectConstructor(0x3502758C, () => new TLReplyKeyboardMarkup());
            TLObjectSerializer.RegisterObjectConstructor(0x48A30254, () => new TLReplyInlineMarkup());
            TLObjectSerializer.RegisterObjectConstructor(0xBB92BA95, () => new TLMessageEntityUnknown());
            TLObjectSerializer.RegisterObjectConstructor(0xFA04579D, () => new TLMessageEntityMention());
            TLObjectSerializer.RegisterObjectConstructor(0x6F635B0D, () => new TLMessageEntityHashtag());
            TLObjectSerializer.RegisterObjectConstructor(0x6CEF8AC7, () => new TLMessageEntityBotCommand());
            TLObjectSerializer.RegisterObjectConstructor(0x6ED02538, () => new TLMessageEntityUrl());
            TLObjectSerializer.RegisterObjectConstructor(0x64E475C2, () => new TLMessageEntityEmail());
            TLObjectSerializer.RegisterObjectConstructor(0xBD610BC9, () => new TLMessageEntityBold());
            TLObjectSerializer.RegisterObjectConstructor(0x826F8B60, () => new TLMessageEntityItalic());
            TLObjectSerializer.RegisterObjectConstructor(0x28A20571, () => new TLMessageEntityCode());
            TLObjectSerializer.RegisterObjectConstructor(0x73924BE0, () => new TLMessageEntityPre());
            TLObjectSerializer.RegisterObjectConstructor(0x76A6D327, () => new TLMessageEntityTextUrl());
            TLObjectSerializer.RegisterObjectConstructor(0x352DCA58, () => new TLMessageEntityMentionName());
            TLObjectSerializer.RegisterObjectConstructor(0x208E68C9, () => new TLInputMessageEntityMentionName());
            TLObjectSerializer.RegisterObjectConstructor(0xEE8C1E86, () => new TLInputChannelEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xAFEB712E, () => new TLInputChannel());
            TLObjectSerializer.RegisterObjectConstructor(0x7F077AD9, () => new TLContactsResolvedPeer());
            TLObjectSerializer.RegisterObjectConstructor(0xAE30253, () => new TLMessageRange());
            TLObjectSerializer.RegisterObjectConstructor(0x3E11AFFB, () => new TLUpdatesChannelDifferenceEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x410DEE07, () => new TLUpdatesChannelDifferenceTooLong());
            TLObjectSerializer.RegisterObjectConstructor(0x2064674E, () => new TLUpdatesChannelDifference());
            TLObjectSerializer.RegisterObjectConstructor(0x94D42EE7, () => new TLChannelMessagesFilterEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xCD77D957, () => new TLChannelMessagesFilter());
            TLObjectSerializer.RegisterObjectConstructor(0x15EBAC1D, () => new TLChannelParticipant());
            TLObjectSerializer.RegisterObjectConstructor(0xA3289A6D, () => new TLChannelParticipantSelf());
            TLObjectSerializer.RegisterObjectConstructor(0x91057FEF, () => new TLChannelParticipantModerator());
            TLObjectSerializer.RegisterObjectConstructor(0x98192D61, () => new TLChannelParticipantEditor());
            TLObjectSerializer.RegisterObjectConstructor(0x8CC5E69A, () => new TLChannelParticipantKicked());
            TLObjectSerializer.RegisterObjectConstructor(0xE3E2E1F9, () => new TLChannelParticipantCreator());
            TLObjectSerializer.RegisterObjectConstructor(0xDE3F3C79, () => new TLChannelParticipantsRecent());
            TLObjectSerializer.RegisterObjectConstructor(0xB4608969, () => new TLChannelParticipantsAdmins());
            TLObjectSerializer.RegisterObjectConstructor(0x3C37BB7A, () => new TLChannelParticipantsKicked());
            TLObjectSerializer.RegisterObjectConstructor(0xB0D1865B, () => new TLChannelParticipantsBots());
            TLObjectSerializer.RegisterObjectConstructor(0xB285A0C6, () => new TLChannelRoleEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x9618D975, () => new TLChannelRoleModerator());
            TLObjectSerializer.RegisterObjectConstructor(0x820BFE8C, () => new TLChannelRoleEditor());
            TLObjectSerializer.RegisterObjectConstructor(0xF56EE2A8, () => new TLChannelsChannelParticipants());
            TLObjectSerializer.RegisterObjectConstructor(0xD0D9B163, () => new TLChannelsChannelParticipant());
            TLObjectSerializer.RegisterObjectConstructor(0xF1EE3E90, () => new TLHelpTermsOfService());
            TLObjectSerializer.RegisterObjectConstructor(0x162ECC1F, () => new TLFoundGif());
            TLObjectSerializer.RegisterObjectConstructor(0x9C750409, () => new TLFoundGifCached());
            TLObjectSerializer.RegisterObjectConstructor(0x450A1C0A, () => new TLMessagesFoundGifs());
            TLObjectSerializer.RegisterObjectConstructor(0xE8025CA2, () => new TLMessagesSavedGifsNotModified());
            TLObjectSerializer.RegisterObjectConstructor(0x2E0709A5, () => new TLMessagesSavedGifs());
            TLObjectSerializer.RegisterObjectConstructor(0x292FED13, () => new TLInputBotInlineMessageMediaAuto());
            TLObjectSerializer.RegisterObjectConstructor(0x3DCD7A87, () => new TLInputBotInlineMessageText());
            TLObjectSerializer.RegisterObjectConstructor(0xF4A59DE1, () => new TLInputBotInlineMessageMediaGeo());
            TLObjectSerializer.RegisterObjectConstructor(0xAAAFADC8, () => new TLInputBotInlineMessageMediaVenue());
            TLObjectSerializer.RegisterObjectConstructor(0x2DAF01A7, () => new TLInputBotInlineMessageMediaContact());
            TLObjectSerializer.RegisterObjectConstructor(0x4B425864, () => new TLInputBotInlineMessageGame());
            TLObjectSerializer.RegisterObjectConstructor(0x2CBBE15A, () => new TLInputBotInlineResult());
            TLObjectSerializer.RegisterObjectConstructor(0xA8D864A7, () => new TLInputBotInlineResultPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0xFFF8FDC4, () => new TLInputBotInlineResultDocument());
            TLObjectSerializer.RegisterObjectConstructor(0x4FA417F2, () => new TLInputBotInlineResultGame());
            TLObjectSerializer.RegisterObjectConstructor(0xA74B15B, () => new TLBotInlineMessageMediaAuto());
            TLObjectSerializer.RegisterObjectConstructor(0x8C7F65E2, () => new TLBotInlineMessageText());
            TLObjectSerializer.RegisterObjectConstructor(0x3A8FD8B8, () => new TLBotInlineMessageMediaGeo());
            TLObjectSerializer.RegisterObjectConstructor(0x4366232E, () => new TLBotInlineMessageMediaVenue());
            TLObjectSerializer.RegisterObjectConstructor(0x35EDB4D4, () => new TLBotInlineMessageMediaContact());
            TLObjectSerializer.RegisterObjectConstructor(0x9BEBAEB9, () => new TLBotInlineResult());
            TLObjectSerializer.RegisterObjectConstructor(0x17DB940B, () => new TLBotInlineMediaResult());
            TLObjectSerializer.RegisterObjectConstructor(0xCCD3563D, () => new TLMessagesBotResults());
            TLObjectSerializer.RegisterObjectConstructor(0x1F486803, () => new TLExportedMessageLink());
            TLObjectSerializer.RegisterObjectConstructor(0xC786DDCB, () => new TLMessageFwdHeader());
            TLObjectSerializer.RegisterObjectConstructor(0x72A3158C, () => new TLAuthCodeTypeSms());
            TLObjectSerializer.RegisterObjectConstructor(0x741CD3E3, () => new TLAuthCodeTypeCall());
            TLObjectSerializer.RegisterObjectConstructor(0x226CCEFB, () => new TLAuthCodeTypeFlashCall());
            TLObjectSerializer.RegisterObjectConstructor(0x3DBB5986, () => new TLAuthSentCodeTypeApp());
            TLObjectSerializer.RegisterObjectConstructor(0xC000BBA2, () => new TLAuthSentCodeTypeSms());
            TLObjectSerializer.RegisterObjectConstructor(0x5353E5A7, () => new TLAuthSentCodeTypeCall());
            TLObjectSerializer.RegisterObjectConstructor(0xAB03C6D9, () => new TLAuthSentCodeTypeFlashCall());
            TLObjectSerializer.RegisterObjectConstructor(0x36585EA4, () => new TLMessagesBotCallbackAnswer());
            TLObjectSerializer.RegisterObjectConstructor(0x26B5DDE6, () => new TLMessagesMessageEditData());
            TLObjectSerializer.RegisterObjectConstructor(0x890C3D89, () => new TLInputBotInlineMessageID());
            TLObjectSerializer.RegisterObjectConstructor(0x3C20629F, () => new TLInlineBotSwitchPM());
            TLObjectSerializer.RegisterObjectConstructor(0x3371C354, () => new TLMessagesPeerDialogs());
            TLObjectSerializer.RegisterObjectConstructor(0xEDCDC05B, () => new TLTopPeer());
            TLObjectSerializer.RegisterObjectConstructor(0xAB661B5B, () => new TLTopPeerCategoryBotsPM());
            TLObjectSerializer.RegisterObjectConstructor(0x148677E2, () => new TLTopPeerCategoryBotsInline());
            TLObjectSerializer.RegisterObjectConstructor(0x637B7ED, () => new TLTopPeerCategoryCorrespondents());
            TLObjectSerializer.RegisterObjectConstructor(0xBD17A14A, () => new TLTopPeerCategoryGroups());
            TLObjectSerializer.RegisterObjectConstructor(0x161D9628, () => new TLTopPeerCategoryChannels());
            TLObjectSerializer.RegisterObjectConstructor(0xFB834291, () => new TLTopPeerCategoryPeers());
            TLObjectSerializer.RegisterObjectConstructor(0xDE266EF5, () => new TLContactsTopPeersNotModified());
            TLObjectSerializer.RegisterObjectConstructor(0x70B772A8, () => new TLContactsTopPeers());
            TLObjectSerializer.RegisterObjectConstructor(0xBA4BAEC5, () => new TLDraftMessageEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0xFD8E711F, () => new TLDraftMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x4EDE3CF, () => new TLMessagesFeaturedStickersNotModified());
            TLObjectSerializer.RegisterObjectConstructor(0xF89D88E5, () => new TLMessagesFeaturedStickers());
            TLObjectSerializer.RegisterObjectConstructor(0xB17F890, () => new TLMessagesRecentStickersNotModified());
            TLObjectSerializer.RegisterObjectConstructor(0x5CE20970, () => new TLMessagesRecentStickers());
            TLObjectSerializer.RegisterObjectConstructor(0x4FCBA9C8, () => new TLMessagesArchivedStickers());
            TLObjectSerializer.RegisterObjectConstructor(0x38641628, () => new TLMessagesStickerSetInstallResultSuccess());
            TLObjectSerializer.RegisterObjectConstructor(0x35E410A8, () => new TLMessagesStickerSetInstallResultArchive());
            TLObjectSerializer.RegisterObjectConstructor(0x6410A5D2, () => new TLStickerSetCovered());
            TLObjectSerializer.RegisterObjectConstructor(0x3407E51B, () => new TLStickerSetMultiCovered());
            TLObjectSerializer.RegisterObjectConstructor(0xAED6DBB2, () => new TLMaskCoords());
            TLObjectSerializer.RegisterObjectConstructor(0x4A992157, () => new TLInputStickeredMediaPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0x438865B, () => new TLInputStickeredMediaDocument());
            TLObjectSerializer.RegisterObjectConstructor(0xBDF9653B, () => new TLGame());
            TLObjectSerializer.RegisterObjectConstructor(0x32C3E77, () => new TLInputGameID());
            TLObjectSerializer.RegisterObjectConstructor(0xC331E80A, () => new TLInputGameShortName());
            TLObjectSerializer.RegisterObjectConstructor(0x58FFFCD0, () => new TLHighScore());
            TLObjectSerializer.RegisterObjectConstructor(0x9A3BFD99, () => new TLMessagesHighScores());
            TLObjectSerializer.RegisterObjectConstructor(0xDC3D824F, () => new TLTextEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x744694E0, () => new TLTextPlain());
            TLObjectSerializer.RegisterObjectConstructor(0x6724ABC4, () => new TLTextBold());
            TLObjectSerializer.RegisterObjectConstructor(0xD912A59C, () => new TLTextItalic());
            TLObjectSerializer.RegisterObjectConstructor(0xC12622C4, () => new TLTextUnderline());
            TLObjectSerializer.RegisterObjectConstructor(0x9BF8BB95, () => new TLTextStrike());
            TLObjectSerializer.RegisterObjectConstructor(0x6C3F19B9, () => new TLTextFixed());
            TLObjectSerializer.RegisterObjectConstructor(0x3C2884C1, () => new TLTextUrl());
            TLObjectSerializer.RegisterObjectConstructor(0xDE5A0DD6, () => new TLTextEmail());
            TLObjectSerializer.RegisterObjectConstructor(0x7E6260D7, () => new TLTextConcat());
            TLObjectSerializer.RegisterObjectConstructor(0x13567E8A, () => new TLPageBlockUnsupported());
            TLObjectSerializer.RegisterObjectConstructor(0x70ABC3FD, () => new TLPageBlockTitle());
            TLObjectSerializer.RegisterObjectConstructor(0x8FFA9A1F, () => new TLPageBlockSubtitle());
            TLObjectSerializer.RegisterObjectConstructor(0xBAAFE5E0, () => new TLPageBlockAuthorDate());
            TLObjectSerializer.RegisterObjectConstructor(0xBFD064EC, () => new TLPageBlockHeader());
            TLObjectSerializer.RegisterObjectConstructor(0xF12BB6E1, () => new TLPageBlockSubheader());
            TLObjectSerializer.RegisterObjectConstructor(0x467A0766, () => new TLPageBlockParagraph());
            TLObjectSerializer.RegisterObjectConstructor(0xC070D93E, () => new TLPageBlockPreformatted());
            TLObjectSerializer.RegisterObjectConstructor(0x48870999, () => new TLPageBlockFooter());
            TLObjectSerializer.RegisterObjectConstructor(0xDB20B188, () => new TLPageBlockDivider());
            TLObjectSerializer.RegisterObjectConstructor(0xCE0D37B0, () => new TLPageBlockAnchor());
            TLObjectSerializer.RegisterObjectConstructor(0x3A58C7F4, () => new TLPageBlockList());
            TLObjectSerializer.RegisterObjectConstructor(0x263D7C26, () => new TLPageBlockBlockquote());
            TLObjectSerializer.RegisterObjectConstructor(0x4F4456D3, () => new TLPageBlockPullquote());
            TLObjectSerializer.RegisterObjectConstructor(0xE9C69982, () => new TLPageBlockPhoto());
            TLObjectSerializer.RegisterObjectConstructor(0xD9D71866, () => new TLPageBlockVideo());
            TLObjectSerializer.RegisterObjectConstructor(0x39F23300, () => new TLPageBlockCover());
            TLObjectSerializer.RegisterObjectConstructor(0xCDE200D1, () => new TLPageBlockEmbed());
            TLObjectSerializer.RegisterObjectConstructor(0x292C7BE9, () => new TLPageBlockEmbedPost());
            TLObjectSerializer.RegisterObjectConstructor(0x8B31C4F, () => new TLPageBlockCollage());
            TLObjectSerializer.RegisterObjectConstructor(0x130C8963, () => new TLPageBlockSlideshow());
            TLObjectSerializer.RegisterObjectConstructor(0xEF1751B5, () => new TLPageBlockChannel());
            TLObjectSerializer.RegisterObjectConstructor(0x8DEE6C44, () => new TLPagePart());
            TLObjectSerializer.RegisterObjectConstructor(0xD7A19D69, () => new TLPageFull());
            TLObjectSerializer.RegisterObjectConstructor(0x85E42301, () => new TLPhoneCallDiscardReasonMissed());
            TLObjectSerializer.RegisterObjectConstructor(0xE095C1A0, () => new TLPhoneCallDiscardReasonDisconnect());
            TLObjectSerializer.RegisterObjectConstructor(0x57ADC690, () => new TLPhoneCallDiscardReasonHangup());
            TLObjectSerializer.RegisterObjectConstructor(0xFAF7E8C9, () => new TLPhoneCallDiscardReasonBusy());
            TLObjectSerializer.RegisterObjectConstructor(0x7D748D04, () => new TLDataJSON());
            TLObjectSerializer.RegisterObjectConstructor(0xCB296BF8, () => new TLLabeledPrice());
            TLObjectSerializer.RegisterObjectConstructor(0xC30AA358, () => new TLInvoice());
            TLObjectSerializer.RegisterObjectConstructor(0xEA02C27E, () => new TLPaymentCharge());
            TLObjectSerializer.RegisterObjectConstructor(0x1E8CAAEB, () => new TLPostAddress());
            TLObjectSerializer.RegisterObjectConstructor(0x909C3F94, () => new TLPaymentRequestedInfo());
            TLObjectSerializer.RegisterObjectConstructor(0xCDC27A1F, () => new TLPaymentSavedCredentialsCard());
            TLObjectSerializer.RegisterObjectConstructor(0xC61ACBD8, () => new TLWebDocument());
            TLObjectSerializer.RegisterObjectConstructor(0x9BED434D, () => new TLInputWebDocument());
            TLObjectSerializer.RegisterObjectConstructor(0xC239D686, () => new TLInputWebFileLocation());
            TLObjectSerializer.RegisterObjectConstructor(0x21E753BC, () => new TLUploadWebFile());
            TLObjectSerializer.RegisterObjectConstructor(0x3F56AEA3, () => new TLPaymentsPaymentForm());
            TLObjectSerializer.RegisterObjectConstructor(0xD1451883, () => new TLPaymentsValidatedRequestedInfo());
            TLObjectSerializer.RegisterObjectConstructor(0x4E5F810D, () => new TLPaymentsPaymentResult());
            TLObjectSerializer.RegisterObjectConstructor(0x6B56B921, () => new TLPaymentsPaymentVerficationNeeded());
            TLObjectSerializer.RegisterObjectConstructor(0x500911E1, () => new TLPaymentsPaymentReceipt());
            TLObjectSerializer.RegisterObjectConstructor(0xFB8FE43C, () => new TLPaymentsSavedInfo());
            TLObjectSerializer.RegisterObjectConstructor(0xC10EB2CF, () => new TLInputPaymentCredentialsSaved());
            TLObjectSerializer.RegisterObjectConstructor(0x3417D728, () => new TLInputPaymentCredentials());
            TLObjectSerializer.RegisterObjectConstructor(0xDB64FD34, () => new TLAccountTmpPassword());
            TLObjectSerializer.RegisterObjectConstructor(0xB6213CDF, () => new TLShippingOption());
            TLObjectSerializer.RegisterObjectConstructor(0x1E36FDED, () => new TLInputPhoneCall());
            TLObjectSerializer.RegisterObjectConstructor(0x5366C915, () => new TLPhoneCallEmpty());
            TLObjectSerializer.RegisterObjectConstructor(0x1B8F4AD1, () => new TLPhoneCallWaiting());
            TLObjectSerializer.RegisterObjectConstructor(0x83761CE4, () => new TLPhoneCallRequested());
            TLObjectSerializer.RegisterObjectConstructor(0x6D003D3F, () => new TLPhoneCallAccepted());
            TLObjectSerializer.RegisterObjectConstructor(0xFFE6AB67, () => new TLPhoneCall());
            TLObjectSerializer.RegisterObjectConstructor(0x50CA4DE1, () => new TLPhoneCallDiscarded());
            TLObjectSerializer.RegisterObjectConstructor(0x9D4C17C0, () => new TLPhoneConnection());
            TLObjectSerializer.RegisterObjectConstructor(0xA2BB35CB, () => new TLPhoneCallProtocol());
            TLObjectSerializer.RegisterObjectConstructor(0xEC82E140, () => new TLPhonePhoneCall());
            TLObjectSerializer.RegisterObjectConstructor(0xEEA8E46E, () => new TLUploadCdnFileReuploadNeeded());
            TLObjectSerializer.RegisterObjectConstructor(0xA99FCA4F, () => new TLUploadCdnFile());
            TLObjectSerializer.RegisterObjectConstructor(0xC982EABA, () => new TLCdnPublicKey());
            TLObjectSerializer.RegisterObjectConstructor(0x5725E40A, () => new TLCdnConfig());
            TLObjectSerializer.RegisterObjectConstructor(0xC09BE45F, () => new TLMessage());
            TLObjectSerializer.RegisterObjectConstructor(0x9E19A1F6, () => new TLMessageService());
        }

        public string TestString
        {
            get;
            set;
        } = "Bello di padella";

        public void Read(TLBinaryReader reader)
        {
            TestString = reader.ReadString();
        }

        public void Write(TLBinaryWriter writer)
        {
            writer.WriteString(TestString);
        }

        public bool IsLayerRequired => false;

        public uint Constructor => 0;
    }

    //public class TLAuthSendCode : ITLObject
    //{
    //    [Flags]
    //    public enum Flag : Int32
    //    {
    //        AllowFlashcall = (1 << 0),
    //        CurrentNumber = (1 << 0),
    //    }

    //    public Flag Flags
    //    {
    //        get;
    //        set;

    //    }

    //    public String PhoneNumber
    //    {
    //        get;
    //        set;
    //    }

    //    public Boolean? CurrentNumber
    //    {
    //        get;
    //        set;
    //    }
    //    public Int32 ApiId
    //    {
    //        get;
    //        set;
    //    }

    //    public String ApiHash
    //    {
    //        get;
    //        set;
    //    }

    //    public void Read(TLBinaryReader reader)
    //    {
    //        Flags = (Flag)reader.ReadInt32();
    //        PhoneNumber = reader.ReadString();

    //        if ((Flags & Flag.CurrentNumber) == Flag.CurrentNumber)
    //            CurrentNumber = reader.ReadBoolean();

    //        ApiId = reader.ReadInt32();
    //        ApiHash = reader.ReadString();
    //    }

    //    public void Write(TLBinaryWriter writer)
    //    {
    //        writer.WriteInt32((Int32)Flags);
    //        writer.WriteString(PhoneNumber);

    //        if ((Flags & Flag.CurrentNumber) == Flag.CurrentNumber)
    //            writer.WriteBoolean(CurrentNumber.Value);

    //        writer.WriteInt32(ApiId);
    //        writer.WriteString(ApiHash);
    //    }

    //    public bool IsLayerRequired => true;

    //    public uint Constructor => 0x86AEF0EC;
    //}

}
