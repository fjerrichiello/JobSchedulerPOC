﻿using Common.DataFactory;
using Common.Messaging;
using JobScheduler.Api.Commands.Authors;
using JobScheduler.Api.Persistence.Repositories;

namespace JobScheduler.Api.CommandHandlers.Authors.AddAuthor;

public class AddAuthorDataFactory(IAuthorRepository _authorRepository)
    : IDataFactory<AddAuthorCommand, CommandMetadata, AddAuthorUnverifiedData, AddAuthorVerifiedData>
{
    public async Task<AddAuthorUnverifiedData> GetUnverifiedDataAsync(
        MessageContainer<AddAuthorCommand, CommandMetadata> container)
    {
        var author = await _authorRepository.GetAsync(container.Message.FirstName, container.Message.LastName);

        return new(author, container.Message.FirstName, container.Message.LastName);
    }

    public AddAuthorVerifiedData GetVerifiedData(AddAuthorUnverifiedData unverifiedData)
    {
        ArgumentNullException.ThrowIfNull(unverifiedData.FirstName);
        ArgumentNullException.ThrowIfNull(unverifiedData.LastName);

        return new(unverifiedData.FirstName, unverifiedData.LastName);
    }
}