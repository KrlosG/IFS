﻿// ******************************************************************************
//  © 2016 Sebastiaan Dammann - damsteen.nl
// 
//  File:           : FileStoreTests.cs
//  Project         : IFS.Tests
// ******************************************************************************

namespace IFS.Tests.Core.Upload {
    using System;

    using Microsoft.Extensions.FileProviders;

    using NSubstitute;

    using NUnit.Framework;

    using Support;

    using Web.Core.Upload;
    using Web.Models;

    [TestFixture]
    public sealed class FileStoreTests {
        [Test]
        public void FileStore_GetFiles_ReadsRootDirectory() {
            // Given
            IFileProvider fileProvider = Substitute.For<IFileProvider>();
            IFileStore store = new FileStore(new FakeFileStoreFileProviderFactory(fileProvider));

            // When
            store.GetFiles();

            // Then
            fileProvider.Received(1).GetDirectoryContents(String.Empty);
        }

        [Test]
        public void FileStore_GetMetadataFile_ReadsCorrectFile() {
            // Given
            IFileProvider fileProvider = Substitute.For<IFileProvider>();
            IFileStore store = new FileStore(new FakeFileStoreFileProviderFactory(fileProvider));

            // When
            store.GetMetadataFile(FileIdentifier.FromString("aaaa"));

            // Then
            fileProvider.Received(1).GetFileInfo("aaaa.metadata");
        }

        [Test]
        public void FileStore_GetDataFile_ReadsCorrectFile() {
            // Given
            IFileProvider fileProvider = Substitute.For<IFileProvider>();
            IFileStore store = new FileStore(new FakeFileStoreFileProviderFactory(fileProvider));

            // When
            store.GetDataFile(FileIdentifier.FromString("aaaa"));

            // Then
            fileProvider.Received(1).GetFileInfo("aaaa.dat");
        }
    }
}
