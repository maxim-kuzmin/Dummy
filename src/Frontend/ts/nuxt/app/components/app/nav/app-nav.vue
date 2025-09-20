<script setup lang="ts">
  import { useAppNavComponent } from '~/utils/domain/app/components/nav/app-nav-component.composable'

  const { aboutPageUrl, fakePageUrl1, fakePageUrl1pn2, fakePageUrl2 } =
    useAppNavComponent()
</script>

<template>
  <nav class="app-nav">
    <ul>
      <li>
        <NuxtLink :to="aboutPageUrl">About</NuxtLink>
      </li>
      <li>
        <NuxtLink :to="fakePageUrl1">Fake1</NuxtLink>
      </li>
      <li>
        <NuxtLink :to="fakePageUrl1pn2">Fake1pn2</NuxtLink>
      </li>
      <li>
        <NuxtLink :to="fakePageUrl2">Fake2</NuxtLink>
      </li>
      <li>
        <a href="#">11111</a>
        <ul>
          <li><a href="#">11111-1</a></li>
          <li><a href="#">11111-2</a></li>
          <li>
            <a href="#">11111-3</a>
            <ul>
              <li><a href="#">11111-3-1</a></li>
              <li><a href="#">11111-3-2</a></li>
              <li>
                <a href="#">11111-3-3</a>
                <ul>
                  <li><a href="#">11111-3-3-1</a></li>
                  <li><a href="#">11111-3-3-2</a></li>
                  <li><a href="#">11111-3-3-3</a></li>
                  <li><a href="#">11111-3-3-4</a></li>
                  <li><a href="#">11111-3-3-5</a></li>
                </ul>
              </li>
              <li><a href="#">11111-3-4</a></li>
              <li><a href="#">11111-3-5</a></li>
            </ul>
          </li>
          <li><a href="#">11111-4</a></li>
          <li><a href="#">11111-5</a></li>
        </ul>
      </li>
      <li>
        <a href="#">22222</a>
        <ul>
          <li><a href="#">22222-1</a></li>
          <li><a href="#">22222-2</a></li>
          <li>
            <a href="#">22222-3</a>
            <ul>
              <li><a href="#">22222-3-1</a></li>
              <li><a href="#">22222-3-2</a></li>
              <li data-selected>
                <a href="#">22222-3-3</a>
                <ul>
                  <li><a href="#">22222-3-3-1</a></li>
                  <li><a href="#">22222-3-3-2</a></li>
                  <li>
                    <a href="#">22222-3-3-3</a>
                    <ul>
                      <li><a href="#">22222-3-3-1</a></li>
                      <li><a href="#">22222-3-3-2</a></li>
                      <li><a href="#">22222-3-3-3</a></li>
                      <li><a href="#">22222-3-3-4</a></li>
                      <li><a href="#">22222-3-3-5</a></li>
                    </ul>
                  </li>
                  <li><a href="#">22222-3-3-4</a></li>
                  <li><a href="#">22222-3-3-5</a></li>
                </ul>
              </li>
              <li><a href="#">22222-3-4</a></li>
              <li><a href="#">22222-3-5</a></li>
            </ul>
          </li>
          <li><a href="#">22222-4</a></li>
          <li><a href="#">22222-5</a></li>
        </ul>
      </li>
      <li><a href="#">33333</a></li>
      <li><a href="#">44444</a></li>
      <li><a href="#">55555</a></li>
    </ul>
  </nav>
</template>
