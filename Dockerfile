# Build source code
FROM registry.redhat.io/dotnet/dotnet-31-rhel7 AS build-env
USER 0
COPY . .
RUN chown -R 1001:0 /opt/app-root && fix-permissions /opt/app-root
USER 1001
RUN /usr/libexec/s2i/assemble
CMD /usr/libexec/s2i/run

# Build runtime image
FROM registry.redhat.io/rhel8/dotnet-31-runtime
USER 0
COPY --from=build-env /opt/app-root/app .
RUN chown -R 1001:0 /opt/app-root && fix-permissions /opt/app-root
HEALTHCHECK --interval=30s --timeout=10s --start-period=5s --retries=3 \
    CMD curl --fail http://localhost:8080/istio || exit 1
USER 1001
EXPOSE 8080
ENTRYPOINT ["dotnet", "istioproject.dll"]
